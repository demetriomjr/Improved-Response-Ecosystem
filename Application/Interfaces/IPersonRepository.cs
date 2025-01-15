using Models.People;

namespace Application.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAll();
        Task<Person?> GetById(uint id);
        Task<Person?> CreatePerson(Person? person);
        Task<bool> UpdatePerson(uint id, Person? person);
        Task<bool> DeletePerson(uint id);
    }
}
