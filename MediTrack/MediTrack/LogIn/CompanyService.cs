using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MediTrack
{
    public static class CompanyService
    {
        // Resolves a company name to its _id (as a string). Returns null if not found.
        public static string GetCompanyId(string companyName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(companyName)) return null;

                var options = new FindOptions
                {
                    Collation = new Collation("en", strength: CollationStrength.Primary)
                };

                var doc = DatabaseService.GetDatabase()
                    .GetCollection<BsonDocument>("companies")
                    .Find(Builders<BsonDocument>.Filter.Eq("name", companyName.Trim()), options)
                    .FirstOrDefault();

                return doc?["_id"].ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error resolving company: {ex.Message}");
                return null;
            }
        }
    }
}