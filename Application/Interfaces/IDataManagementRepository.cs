namespace Application.Interfaces
{
    public interface IDataManagementRepository<T> : IDependencyRepository
    {
        Task<List<T>> GetAllAsync(Func<T, bool> predicate, CancellationToken ct);
        Task<T?> GetByIdAsync(uint id, CancellationToken ct);
        Task<T?> CreateAsync(T? person, CancellationToken ct);
        Task<bool> UpdateAsync(uint id, T? person, CancellationToken ct);
        Task<bool> DeleteAsync(uint id, CancellationToken ct);
    }
}
