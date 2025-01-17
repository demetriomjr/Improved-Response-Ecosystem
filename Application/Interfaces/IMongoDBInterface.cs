using MongoDB.Driver;

namespace Application.Interfaces
{
    public interface IMongoDBInterface
    {
        public IMongoClient GetClient();
        public Task<IMongoCollection<T>> GetCollectionAsync<T>();
    }
}
