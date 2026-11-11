using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DBConfigSetup
{
    internal class Program
    {
        private const string PasswordPlaceholder = "<db_password>";

        private static readonly string _configPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Meditrack", "db.config");

        private static readonly byte[] _entropy =
            Encoding.UTF8.GetBytes("Meditrack-v1-salt");

        static void Main(string[] args)
        {
            // Silent mode: called by installer with arguments
            if (args.Length > 0)
            {
                RunSilent(args);
                return;
            }

            // Interactive mode: developer runs manually
            RunInteractive();
        }

        // Usage (silent):
        //   DBConfigSetup.exe --connection-string "mongodb+srv://kriz_user:<db_password>@meditrack.3j0hqfm.mongodb.net/" --password "MyP@ss"
        // --password is optional; only needed if the string contains <db_password>
        private static void RunSilent(string[] args)
        {
            try
            {
                string connectionString = GetArg(args, "--connection-string");
                string password = GetOptionalArg(args, "--password");

                connectionString = ApplyPassword(connectionString, password);
                Validate(connectionString);

                Save(connectionString);
            }
            catch (Exception ex)
            {
                // Write to a log file since there's no console in silent mode
                Directory.CreateDirectory(Path.GetDirectoryName(_configPath)!);
                File.WriteAllText(
                    Path.Combine(Path.GetDirectoryName(_configPath)!, "setup-error.log"),
                    ex.Message);
            }
        }

        private static void RunInteractive()
        {
            Console.WriteLine("=== Meditrack DB Config Setup (MongoDB) ===");
            Console.WriteLine();

            Console.WriteLine("Paste your MongoDB connection string.");
            Console.WriteLine("Example: mongodb+srv://user:<db_password>@cluster.mongodb.net/");
            Console.Write("\nConnection string: ");
            string connectionString = Console.ReadLine()?.Trim() ?? "";

            if (connectionString.Contains(PasswordPlaceholder))
            {
                Console.Write("Password:          ");
                string password = ReadPasswordMasked();
                connectionString = ApplyPassword(connectionString, password);
            }

            try
            {
                Validate(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nInvalid connection string: {ex.Message}");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Connection string:\n{Mask(connectionString)}");
            Console.Write("\nConfirm? (y/n): ");

            if (Console.ReadLine()?.Trim().ToLower() != "y")
            {
                Console.WriteLine("Cancelled.");
                return;
            }

            Save(connectionString);
            Console.WriteLine($"\nSaved to:\n{_configPath}");
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        // Replaces <db_password> with the URL-encoded password
        // (special characters like @ : / # ? must be percent-encoded in Mongo URIs)
        private static string ApplyPassword(string connectionString, string? password)
        {
            if (!connectionString.Contains(PasswordPlaceholder))
                return connectionString;

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException(
                    "Connection string contains <db_password> but no password was provided.");

            return connectionString.Replace(
                PasswordPlaceholder, Uri.EscapeDataString(password));
        }

        private static void Validate(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string is empty.");

            if (!connectionString.StartsWith("mongodb://", StringComparison.OrdinalIgnoreCase) &&
                !connectionString.StartsWith("mongodb+srv://", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(
                    "Connection string must start with mongodb:// or mongodb+srv://");

            if (connectionString.Contains(PasswordPlaceholder))
                throw new ArgumentException("Password placeholder was not replaced.");
        }

        // Hides the password when displaying the connection string
        private static string Mask(string connectionString)
        {
            return Regex.Replace(
                connectionString,
                @"(?<=://[^:/@]+:)[^@]*(?=@)",
                "********");
        }

        private static void Save(string plaintext)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_configPath)!);

            byte[] encrypted = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(plaintext),
                _entropy,
                DataProtectionScope.LocalMachine);

            File.WriteAllBytes(_configPath, encrypted);
        }

        private static string GetArg(string[] args, string key)
        {
            int index = Array.IndexOf(args, key);
            if (index < 0 || index + 1 >= args.Length)
                throw new ArgumentException($"Missing argument: {key}");
            return args[index + 1];
        }

        private static string? GetOptionalArg(string[] args, string key)
        {
            int index = Array.IndexOf(args, key);
            if (index < 0 || index + 1 >= args.Length)
                return null;
            return args[index + 1];
        }

        private static string ReadPasswordMasked()
        {
            var sb = new StringBuilder();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Backspace && sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Enter)
                {
                    sb.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return sb.ToString();
        }
    }
}