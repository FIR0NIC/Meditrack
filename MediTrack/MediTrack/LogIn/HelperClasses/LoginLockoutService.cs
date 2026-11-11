using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MediTrack
{
    public class LockoutInfo
    {
        public bool IsLockedOut { get; set; }
        public int RemainingSeconds { get; set; }
        public int RemainingAttempts { get; set; }
    }

    // Tracks failed logins per username in the "loginLockouts" collection.
    // Works for unknown usernames too, so guessing usernames also gets locked out.
    public class LoginLockoutService
    {
        private const int MaxAttempts = 5;
        private const int LockoutMinutes = 5;

        private static IMongoCollection<BsonDocument> Col =>
            DatabaseService.GetDatabase().GetCollection<BsonDocument>("loginLockouts");

        private static string Key(string username, string companyId) =>
            $"{companyId}:{(username ?? "").Trim().ToLowerInvariant()}";

        public int GetMaxAttempts() => MaxAttempts;

        public int GetLockoutMinutes() => LockoutMinutes;

        public async Task<LockoutInfo> CheckLockoutStatusAsync(string username, string companyId)
        {
            var doc = await Col
                .Find(Builders<BsonDocument>.Filter.Eq("_id", Key(username, companyId)))
                .FirstOrDefaultAsync();

            if (doc == null)
                return new LockoutInfo { IsLockedOut = false, RemainingAttempts = MaxAttempts };

            var lockedValue = doc.GetValue("lockedUntil", BsonNull.Value);
            if (lockedValue.IsBsonDateTime)
            {
                var lockedUntil = lockedValue.ToUniversalTime();
                if (lockedUntil > DateTime.UtcNow)
                {
                    return new LockoutInfo
                    {
                        IsLockedOut = true,
                        RemainingSeconds = (int)Math.Ceiling((lockedUntil - DateTime.UtcNow).TotalSeconds),
                        RemainingAttempts = 0
                    };
                }
            }

            int attempts = doc.GetValue("failedAttempts", 0).ToInt32();
            return new LockoutInfo
            {
                IsLockedOut = false,
                RemainingAttempts = Math.Max(0, MaxAttempts - attempts)
            };
        }

        public async Task RecordFailedAttemptAsync(string username, string companyId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", Key(username, companyId));

            var doc = await Col.FindOneAndUpdateAsync(
                filter,
                Builders<BsonDocument>.Update
                    .Inc("failedAttempts", 1)
                    .Set("lastAttemptAt", DateTime.UtcNow),
                new FindOneAndUpdateOptions<BsonDocument>
                {
                    IsUpsert = true,
                    ReturnDocument = ReturnDocument.After
                });

            // Reached the limit: lock the account and start the counter fresh for next time
            if (doc["failedAttempts"].ToInt32() >= MaxAttempts)
            {
                await Col.UpdateOneAsync(filter, Builders<BsonDocument>.Update
                    .Set("failedAttempts", 0)
                    .Set("lockedUntil", DateTime.UtcNow.AddMinutes(LockoutMinutes)));
            }
        }

        public async Task ResetLockoutAsync(string username, string companyId)
        {
            await Col.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("_id", Key(username, companyId)));
        }
    }
}