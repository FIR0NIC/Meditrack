using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MediTrack
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Role { get; set; }
        public string CompanyName { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string SessionToken { get; set; }
        public string ErrorMessage { get; set; }
        public ControlToFocus FocusTarget { get; set; }
        public bool IsLockedOut { get; set; }
        public int RemainingSeconds { get; set; }
        public int RemainingAttempts { get; set; }
    }

    public enum ControlToFocus
    {
        None,
        Username,
        Password,
        Company
    }

    public class SessionInfo
    {
        public bool HasActiveSession { get; set; }
        public string DeviceInfo { get; set; }
        public DateTime LoginTime { get; set; }
    }

    public class UserValidationResult
    {
        public string UserId { get; set; }
        public string StoredPassword { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }

    public class LoginService
    {
        private readonly LoginLockoutService _lockoutService = new LoginLockoutService();

        // Case-insensitive matching for company names and usernames
        private static readonly FindOptions CaseInsensitive = new FindOptions
        {
            Collation = new Collation("en", strength: CollationStrength.Primary)
        };

        private static IMongoDatabase Db => DatabaseService.GetDatabase();
        private static IMongoCollection<BsonDocument> Companies => Db.GetCollection<BsonDocument>("companies");
        private static IMongoCollection<BsonDocument> Users => Db.GetCollection<BsonDocument>("users");
        private static IMongoCollection<BsonDocument> Sessions => Db.GetCollection<BsonDocument>("userSessions");
        private static IMongoCollection<BsonDocument> Audit => Db.GetCollection<BsonDocument>("loginAudit");

        public async Task<LoginResult> AuthenticateAsync(string username, string password, string company)
        {
            try
            {
                // Validate company
                var companyDoc = string.IsNullOrWhiteSpace(company)
                    ? null
                    : await ValidateCompanyAsync(company);

                if (companyDoc == null)
                {
                    await WriteAuditAsync(null, null, username, false, "unknown_company");
                    return new LoginResult
                    {
                        Success = false,
                        ErrorMessage = "Company name not found.",
                        FocusTarget = ControlToFocus.Company
                    };
                }

                bool companyActive = !companyDoc.TryGetValue("isActive", out var ca) || !ca.IsBoolean || ca.AsBoolean;
                if (!companyActive)
                {
                    return new LoginResult
                    {
                        Success = false,
                        ErrorMessage = "This company account is disabled. Please contact support.",
                        FocusTarget = ControlToFocus.Company
                    };
                }

                var companyOid = companyDoc["_id"].AsObjectId;
                string companyId = companyOid.ToString();
                string companyName = companyDoc.GetValue("name", company).ToString(); // canonical spelling

                // CHECK LOCKOUT STATUS FIRST
                var lockoutInfo = await _lockoutService.CheckLockoutStatusAsync(username, companyId);
                if (lockoutInfo.IsLockedOut)
                {
                    await WriteAuditAsync(companyId, null, username, false, "locked");
                    return new LoginResult
                    {
                        Success = false,
                        IsLockedOut = true,
                        RemainingSeconds = lockoutInfo.RemainingSeconds,
                        ErrorMessage = $"Account is temporarily locked.\n\nPlease try again in {lockoutInfo.RemainingSeconds / 60} minute(s) and {lockoutInfo.RemainingSeconds % 60} second(s).",
                        FocusTarget = ControlToFocus.None
                    };
                }

                // Validate user inside THIS company only
                var userData = await ValidateUserAsync(companyOid, username);
                if (userData == null)
                {
                    return await FailedAttemptAsync(username, companyId, null, "unknown_user",
                        "Username not found under the specified company.\n", ControlToFocus.Username, showRemaining: false);
                }

                // Disabled account
                if (!userData.IsActive)
                {
                    await WriteAuditAsync(companyId, userData.UserId, username, false, "inactive");
                    return new LoginResult
                    {
                        Success = false,
                        ErrorMessage = "This account is disabled. Please contact an administrator.",
                        FocusTarget = ControlToFocus.Username
                    };
                }

                // Validate password (plaintext - demo only)
                if (userData.StoredPassword != password)
                {
                    return await FailedAttemptAsync(username, companyId, userData.UserId, "bad_password",
                        "Incorrect password.\n", ControlToFocus.Password, showRemaining: true);
                }

                // SUCCESSFUL LOGIN - Reset lockout
                await _lockoutService.ResetLockoutAsync(username, companyId);

                // Check for existing active session
                var sessionCheck = await CheckExistingSessionAsync(userData.UserId);
                if (sessionCheck.HasActiveSession)
                {
                    await WriteAuditAsync(companyId, userData.UserId, username, false, "session_active");
                    return new LoginResult
                    {
                        Success = false,
                        ErrorMessage = "You are already logged in on another device.\n\n" +
                                       "Please log out from the other device first before logging in here.\n\n" +
                                       $"Device: {sessionCheck.DeviceInfo}\n" +
                                       $"Login time: {sessionCheck.LoginTime:yyyy-MM-dd hh:mm:ss tt}",
                        FocusTarget = ControlToFocus.None
                    };
                }

                // Create new session
                string sessionToken = Guid.NewGuid().ToString();
                await CreateSessionAsync(userData.UserId, companyId, sessionToken, Environment.MachineName);

                await Users.UpdateOneAsync(
                    Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(userData.UserId)),
                    Builders<BsonDocument>.Update.Set("lastLoginAt", DateTime.UtcNow));

                await WriteAuditAsync(companyId, userData.UserId, username, true, "login_ok");

                // Success
                return new LoginResult
                {
                    Success = true,
                    Role = userData.Role,            // "Admin", "Doctor" or "Receptionist"
                    CompanyName = companyName,
                    CompanyId = companyId,
                    UserId = userData.UserId,
                    SessionToken = sessionToken
                };
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    Success = false,
                    ErrorMessage = $"Login failed: {ex.Message}",
                    FocusTarget = ControlToFocus.None
                };
            }
        }

        public async Task<bool> ValidateSessionAsync(string userId, string sessionToken)
        {
            try
            {
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(sessionToken))
                    return false;
                if (!ObjectId.TryParse(userId, out var oid))
                    return false;

                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("userId", oid),
                    Builders<BsonDocument>.Filter.Eq("sessionToken", sessionToken),
                    Builders<BsonDocument>.Filter.Eq("isActive", true));

                return await Sessions.CountDocumentsAsync(filter) > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Session validation error: {ex.Message}");
                return false;
            }
        }

        public async Task LogoutSessionAsync(string userId, string sessionToken)
        {
            try
            {
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(sessionToken))
                    return;
                if (!ObjectId.TryParse(userId, out var oid))
                    return;

                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("userId", oid),
                    Builders<BsonDocument>.Filter.Eq("sessionToken", sessionToken));

                await Sessions.UpdateOneAsync(filter, Builders<BsonDocument>.Update
                    .Set("isActive", false)
                    .Set("logoutTime", DateTime.UtcNow));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Session logout error: {ex.Message}");
            }
        }

        public async Task TerminateAllSessionsAsync(string userId)
        {
            try
            {
                if (!ObjectId.TryParse(userId, out var oid))
                    return;

                await Sessions.UpdateManyAsync(
                    Builders<BsonDocument>.Filter.And(
                        Builders<BsonDocument>.Filter.Eq("userId", oid),
                        Builders<BsonDocument>.Filter.Eq("isActive", true)),
                    Builders<BsonDocument>.Update
                        .Set("isActive", false)
                        .Set("logoutTime", DateTime.UtcNow));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Session termination error: {ex.Message}");
            }
        }

        public async Task<LockoutInfo> GetLockoutStatusAsync(string username, string companyId)
        {
            return await _lockoutService.CheckLockoutStatusAsync(username, companyId);
        }

        public int GetMaxAttempts() => _lockoutService.GetMaxAttempts();

        public int GetLockoutMinutes() => _lockoutService.GetLockoutMinutes();

        // ---------------------------------------------------------------
        // Helpers
        // ---------------------------------------------------------------

        // Records a failed attempt, then returns either a lockout or a normal failure result
        private async Task<LoginResult> FailedAttemptAsync(
            string username, string companyId, string userId, string reason,
            string message, ControlToFocus focus, bool showRemaining)
        {
            await _lockoutService.RecordFailedAttemptAsync(username, companyId);
            var info = await _lockoutService.CheckLockoutStatusAsync(username, companyId);

            await WriteAuditAsync(companyId, userId, username, false, info.IsLockedOut ? "locked_now" : reason);

            if (info.IsLockedOut)
            {
                return new LoginResult
                {
                    Success = false,
                    IsLockedOut = true,
                    RemainingSeconds = info.RemainingSeconds,
                    ErrorMessage = $"Too many failed attempts. Account is locked for {_lockoutService.GetLockoutMinutes()} minutes.",
                    FocusTarget = focus
                };
            }

            return new LoginResult
            {
                Success = false,
                ErrorMessage = message,
                FocusTarget = focus,
                RemainingAttempts = showRemaining ? info.RemainingAttempts : 0
            };
        }

        private static async Task<BsonDocument> ValidateCompanyAsync(string company)
        {
            return await Companies
                .Find(Builders<BsonDocument>.Filter.Eq("name", company.Trim()), CaseInsensitive)
                .FirstOrDefaultAsync();
        }

        // The same username can exist in different companies, so always search within one company
        private async Task<UserValidationResult> ValidateUserAsync(ObjectId companyOid, string username)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("companyId", companyOid),
                Builders<BsonDocument>.Filter.Eq("username", username));

            var doc = await Users.Find(filter, CaseInsensitive).FirstOrDefaultAsync();

            if (doc == null)
                return null;

            bool isActive = !doc.TryGetValue("isActive", out var active)
                            || !active.IsBoolean
                            || active.AsBoolean;

            return new UserValidationResult
            {
                UserId = doc["_id"].AsObjectId.ToString(),
                StoredPassword = doc.TryGetValue("password", out var pw) && pw.IsString ? pw.AsString : "",
                Role = doc.GetValue("role", "").ToString(),
                IsActive = isActive
            };
        }

        private async Task<SessionInfo> CheckExistingSessionAsync(string userId)
        {
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("userId", ObjectId.Parse(userId)),
                Builders<BsonDocument>.Filter.Eq("isActive", true));

            var session = await Sessions.Find(filter).FirstOrDefaultAsync();

            if (session == null)
                return new SessionInfo { HasActiveSession = false };

            DateTime localLoginTime = session.GetValue("loginTime", BsonNull.Value).IsBsonDateTime
                ? session["loginTime"].ToUniversalTime().ToLocalTime()   // Convert UTC to local
                : DateTime.Now;

            return new SessionInfo
            {
                HasActiveSession = true,
                DeviceInfo = session.GetValue("deviceInfo", "Unknown device").ToString(),
                LoginTime = localLoginTime
            };
        }

        private async Task CreateSessionAsync(string userId, string companyId, string sessionToken, string deviceInfo)
        {
            await Sessions.InsertOneAsync(new BsonDocument
            {
                { "companyId", ObjectId.Parse(companyId) },
                { "userId", ObjectId.Parse(userId) },
                { "sessionToken", sessionToken },
                { "deviceInfo", deviceInfo ?? "Unknown" },
                { "loginTime", DateTime.UtcNow },
                { "lastActivity", DateTime.UtcNow },
                { "isActive", true }
            });
        }

        private async Task WriteAuditAsync(string companyId, string userId, string username, bool success, string reason)
        {
            try
            {
                BsonValue cid = !string.IsNullOrEmpty(companyId) && ObjectId.TryParse(companyId, out var coid)
                    ? (BsonValue)coid : BsonNull.Value;
                BsonValue uid = !string.IsNullOrEmpty(userId) && ObjectId.TryParse(userId, out var oid)
                    ? (BsonValue)oid : BsonNull.Value;

                await Audit.InsertOneAsync(new BsonDocument
                {
                    { "companyId", cid },
                    { "userId", uid },
                    { "username", username },
                    { "success", success },
                    { "reason", reason },
                    { "machine", Environment.MachineName },
                    { "timestamp", DateTime.UtcNow }
                });
            }
            catch
            {
                // Never block a login because the audit write failed
            }
        }
    }
}