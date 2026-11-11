using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTrack
{
    public static class DatabaseService
    {
        private const string DefaultDatabaseName = "meditrack";

        private static string _connectionString;
        private static IMongoClient _client;

        public static string ConnectionString
        {
            get => _connectionString;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Connection string cannot be null or empty.");
                _connectionString = value;
            }
        }

        // Where the config is saved when this app writes it (matches the setup tool)
        private static readonly string _savePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Meditrack", "db.config");

        // Places to look for db.config, in order.
        // ProgramData is machine-wide, so it works even if the installer ran as a different user.
        private static readonly string[] _searchPaths =
        {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),       "Meditrack", "db.config"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Meditrack", "db.config"),
            Path.Combine(AppContext.BaseDirectory, "db.config"),
        };

        // Must match the entropy used by the setup tool exactly.
        private static readonly byte[] _entropy =
            Encoding.UTF8.GetBytes("Meditrack-v1-salt");

        public static async Task InitializeAsync()
        {
            try
            {
                ConnectionString = Load();

                _client = new MongoClient(ConnectionString);

                // Verify the connection works
                await _client.GetDatabase("admin")
                    .RunCommandAsync<BsonDocument>(new BsonDocument("ping", 1));
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(
                    "No database configuration found.\n\n" +
                    "Please run the DB Config Admin tool to set up the connection before launching MediTrack.\n\n" +
                    "Looked in:\n" + ex.Message,
                    "Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (CryptographicException)
            {
                MessageBox.Show(
                    "The database configuration file could not be decrypted.\n\n" +
                    "It may have been created on another machine. Please run the DB Config Admin tool again.",
                    "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException || ex is MongoConfigurationException)
            {
                MessageBox.Show($"Invalid connection string: {ex.Message}",
                    "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to database: {ex.Message}",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static IMongoClient GetClient()
            => _client ?? throw new InvalidOperationException("Database not initialized.");

        public static IMongoDatabase GetDatabase()
        {
            string name = MongoUrl.Create(ConnectionString).DatabaseName ?? DefaultDatabaseName;
            return GetClient().GetDatabase(name);
        }

        public static void SaveConnectionString(string plaintext)
        {
            ConnectionString = plaintext;

            Directory.CreateDirectory(Path.GetDirectoryName(_savePath)!);

            byte[] encrypted = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(plaintext),
                _entropy,
                DataProtectionScope.LocalMachine);

            File.WriteAllBytes(_savePath, encrypted);
        }

        private static string Load()
        {
            string path = _searchPaths.FirstOrDefault(File.Exists);

            if (path == null)
                throw new FileNotFoundException(string.Join("\n", _searchPaths), _searchPaths[0]);

            byte[] cipher = File.ReadAllBytes(path);
            byte[] plain = ProtectedData.Unprotect(cipher, _entropy, DataProtectionScope.LocalMachine);
            return Encoding.UTF8.GetString(plain);
        }
    }
}