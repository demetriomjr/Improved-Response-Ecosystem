using Application.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.DatabaseDependency
{
    public class MongoDBContext : IMongoDBInterface
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _client;

        public MongoDBContext(string connectionString, string database)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(database);
        }

        public IMongoClient GetClient()
        {
            return _client;
        }

        public Task<IMongoCollection<T>> GetCollectionAsync<T>()
        {
            return Task.FromResult(_database.GetCollection<T>(typeof(T).Name));
        }
    }
}
