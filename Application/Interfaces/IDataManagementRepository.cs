using Models.People;

namespace Application.Interfaces
{
    public interface IDataManagementRepository
    {
        Task<List<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(uint id);
        Task<Person?> CreateAsync(Person? person);
        Task<bool> UpdateAsync(uint id, Person? person);
        Task<bool> DeleteAsync(uint id);
    }
}
