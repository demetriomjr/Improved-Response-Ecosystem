using Application.Interfaces;
using Models.People;

namespace Application.API.People
{
    public class PeopleController
    {
        private readonly IDataManagementRepository _personRepository;

        public PeopleController(IDataManagementRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person?> GetAsync(uint id)
        {
            var result = await _personRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<Person?> Post(Person? item = default)
        {
            if (item == null)
                return await Task.FromResult<Person?>(null);

            var createdPerson = await _personRepository.CreateAsync(item);
            return createdPerson != null ? createdPerson : null;
        }

        public async Task<bool> Put(uint id, Person? item)
        {
            if (item == null)
                return false;

            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return false;

            return await _personRepository.UpdateAsync(id, item);
        }

        public async Task<bool> Delete(uint id)
        {
            return await _personRepository.DeleteAsync(id);
        }
    }
}
