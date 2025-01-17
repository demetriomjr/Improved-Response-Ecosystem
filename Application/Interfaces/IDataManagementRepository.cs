using CToken = System.Threading.CancellationToken;

namespace Application.Interfaces
{
    public interface IDataManagementRepository<T> : IDependencyRepository
    {
        Task<List<T>> GetAllAsync(Func<T, bool> predicate, CToken ct);
        Task<T?> GetByIdAsync(uint id, CToken ct);
        Task<T?> CreateAsync(T? person, CToken ct);
        Task<bool> UpdateAsync(uint id, T? person, CToken ct);
        Task<bool> DeleteAsync(uint id, CToken ct);
    }
}
