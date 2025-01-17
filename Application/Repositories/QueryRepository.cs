using Application.Interfaces;
using MongoDB.Driver;
using System.Diagnostics;

namespace Application.Repositories
{
    public class QueryRepository<T> : IRepository<T> where T : class
    {
        private readonly IMongoDBInterface _context;

        public QueryRepository(IMongoDBInterface context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync(Func<T, bool> predicate, CToken ct)
        {
            var collection = await _context.GetCollectionAsync<T>();
            var result = collection.AsQueryable().Where(predicate).ToList();
            return result;
        }

        public async Task<T?> GetByIdAsync(uint id, CToken ct)
        {
            var collection = await _context.GetCollectionAsync<T>();
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await collection.Find(filter).FirstOrDefaultAsync(ct);
            return result;
        }

        public async Task<T> CreateAsync(T entity, CToken ct)
        {
            var collection = await _context.GetCollectionAsync<T>();
            await collection.InsertOneAsync(entity, null, ct);
            return entity;
        }

        public async Task<bool> UpdateAsync(List<T> list, CToken ct)
        {
            var client = _context.GetClient();
            using (var session = await client.StartSessionAsync(null, ct))
            {
                session.StartTransaction();
                try
                {
                    var collection = await _context.GetCollectionAsync<T>();
                    foreach (var item in list)
                    {
                        var id = item.GetType().GetProperty("Id");
                        var idValue = id?.GetValue(item);
                        var filter = Builders<T>.Filter.Eq("Id", idValue);
                        await collection.ReplaceOneAsync(filter, item, new ReplaceOptions(), ct);
                    }
                    await session.CommitTransactionAsync(ct);
                    return true;
                }
                catch
                {
                    if (Debugger.IsAttached) throw;
                    await session.AbortTransactionAsync(ct);
                    return false;
                }
            }
        }

        public async Task<bool> UpdateAsync(T item, CToken ct)
        {
            try
            {
                var collection = await _context.GetCollectionAsync<T>();
                var id = item.GetType().GetProperty("Id");
                var idValue = id?.GetValue(item);
                var filter = Builders<T>.Filter.Eq("Id", idValue);
                var result = await collection.ReplaceOneAsync(filter, item, new ReplaceOptions(), ct);
                return result.ModifiedCount > 0;
            }
            catch
            {
                if (Debugger.IsAttached) throw;
                return false;
            }
        }

        public async Task<bool> DeleteAsync(uint id, CToken ct)
        {
            var collection = await _context.GetCollectionAsync<T>();
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await collection.DeleteOneAsync(filter, ct);
            return result.DeletedCount > 0;
        }
    }
}
