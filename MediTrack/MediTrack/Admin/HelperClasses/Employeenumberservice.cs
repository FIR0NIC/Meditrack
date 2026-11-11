using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace MediTrack
{
    // Hands out employee numbers (EMP-0001, EMP-0002, ...) separately for each company.
    // The counter is increased in one atomic step, so two admins adding users at the
    // same moment can never receive the same number. Numbers are never reused after a delete.
    public static class EmployeeNumberService
    {
        private static IMongoCollection<BsonDocument> Counters =>
            DatabaseService.GetDatabase().GetCollection<BsonDocument>("counters");

        // Pass a session when this must be part of a transaction (e.g. company registration)
        public static async Task<string> NextAsync(ObjectId companyId, IClientSessionHandle session = null)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", $"employeeNo:{companyId}");
            var update = Builders<BsonDocument>.Update
                .Inc("seq", 1)
                .SetOnInsert("companyId", companyId);
            var options = new FindOneAndUpdateOptions<BsonDocument>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };

            var doc = session == null
                ? await Counters.FindOneAndUpdateAsync(filter, update, options)
                : await Counters.FindOneAndUpdateAsync(session, filter, update, options);

            return Format(doc["seq"].ToInt32());
        }

        public static string Format(int number) => $"EMP-{number:0000}";
    }
}