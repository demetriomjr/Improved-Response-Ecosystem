namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Func<T, bool> predicate, CToken ct);
        Task<T?> GetByIdAsync(uint id, CToken ct);
        Task<T> CreateAsync(T item, CToken ct);
        Task<bool> UpdateAsync(T item, CToken ct);
        Task<bool> UpdateAsync(List<T> item, CToken ct);
        Task<bool> DeleteAsync(uint id, CToken ct);
    }
}
