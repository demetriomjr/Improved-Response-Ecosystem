using Application.Interfaces;
using Models.People;

namespace Application.API.People
{
    public class PeopleController
    {
        private readonly IDataManagementRepository<Person> _personRepository;

        public PeopleController(IDataManagementRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetAsync(Func<Person, bool> predicate)
        {
            return await _personRepository.GetAllAsync(predicate, CancellationToken.None);
        }

        public async Task<Person?> GetAsync(uint id)
        {
            var result = await _personRepository.GetByIdAsync(id, CancellationToken.None);
            return result;
        }

        public async Task<Person?> Post(Person? item = default)
        {
            if (item == null)
                return await Task.FromResult<Person?>(null);

            var createdPerson = await _personRepository.CreateAsync(item, CancellationToken.None);
            return createdPerson != null ? createdPerson : null;
        }

        public async Task<bool> Put(uint id, Person? item)
        {
            if (item == null)
                return false;

            var person = await _personRepository.GetByIdAsync(id, CancellationToken.None);
            if (person == null)
                return false;

            return await _personRepository.UpdateAsync(id, item, CancellationToken.None);
        }

        public async Task<bool> Delete(uint id)
        {
            return await _personRepository.DeleteAsync(id, CancellationToken.None);
        }
    }
}
