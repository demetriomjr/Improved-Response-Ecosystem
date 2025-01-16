namespace Application.Interfaces
{
    public interface IWebApiContext<T> where T : class
    {
        public Task<List<T>> GetAsync(Func<T, bool> predicate, CancellationToken ct);
        public Task<T?> GetAsync(uint id, CancellationToken ct);
        public Task<T?> Post(T? item, CancellationToken ct);
        public Task<bool> Put(uint id, T? item, CancellationToken ct);
        public Task<bool> Delete(uint id, CancellationToken ct);
    }
}
