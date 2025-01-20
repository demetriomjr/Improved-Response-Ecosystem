namespace Application.Interfaces
{
    public interface IWebAPIContext<T>
    {
        Task<List<T>> Get(Func<T, bool> predicate, CToken ct);
        Task<T?> Get(uint id, CToken ct);
        Task<T> Post(T item, CToken ct);
        Task<bool> Put(T item, CToken ct);
        Task<bool> Delete(uint id, CToken ct);
    }
}
