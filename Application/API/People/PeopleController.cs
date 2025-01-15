using Application.Interfaces;
using Models.People;

namespace Application.API.People
{
    public class PeopleController
    {
        private readonly IPersonRepository _personRepository;

        public PeopleController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetAsync()
        {
            return await _personRepository.GetAll();
        }

        public async Task<Person?> GetAsync(uint id)
        {
            var result = await _personRepository.GetById(id);
            return result;
        }

        public async Task<Person?> Post(Person? item = default)
        {
            if (item == null)
                return await Task.FromResult<Person?>(null);

            var createdPerson = await _personRepository.CreatePerson(item);
            return createdPerson != null ? createdPerson : null;
        }

        public async Task<bool> Put(uint id, Person? item)
        {
            if (item == null)
                return false;

            var person = await _personRepository.GetById(id);
            if (person == null)
                return false;

            return await _personRepository.UpdatePerson(id, item);
        }

        public async Task<bool> Delete(uint id)
        {
            return await _personRepository.DeletePerson(id);
        }
    }
}
