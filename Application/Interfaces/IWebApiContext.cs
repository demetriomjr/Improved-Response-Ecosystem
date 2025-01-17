using CToken = System.Threading.CancellationToken;

namespace Application.Interfaces
{
    public interface IWebApiContext<T> where T : class
    {
        public Task<List<T>> GetAsync(Func<T, bool> predicate, CToken ct);
        public Task<T?> GetAsync(uint id, CToken ct);
        public Task<T?> Post(T? item, CToken ct);
        public Task<bool> Put(uint id, T? item, CToken ct);
        public Task<bool> Delete(uint id, CToken ct);
    }
}
