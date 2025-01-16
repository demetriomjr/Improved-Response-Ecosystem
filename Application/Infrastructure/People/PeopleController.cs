using Application.Interfaces;
using Models.People;

namespace Application.Infrastructure.People
{
    public class PeopleController : IWebApiContext<Person>
    {
        private readonly IDataManagementRepository<Person> _personRepository;

        public PeopleController(IDataManagementRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetAsync(Func<Person, bool> predicate, CancellationToken ct)
        {
            return await _personRepository.GetAllAsync(predicate, ct);
        }

        public async Task<Person?> GetAsync(uint id, CancellationToken ct)
        {
            var result = await _personRepository.GetByIdAsync(id, ct);
            return result;
        }

        public async Task<Person?> Post(Person? item, CancellationToken ct)
        {
            if (item == null)
                return await Task.FromResult<Person?>(null);

            var createdPerson = await _personRepository.CreateAsync(item, ct);
            return createdPerson != null ? createdPerson : null;
        }

        public async Task<bool> Put(uint id, Person? item, CancellationToken ct)
        {
            if (item == null)
                return false;

            var person = await _personRepository.GetByIdAsync(id, ct);
            if (person == null)
                return false;

            return await _personRepository.UpdateAsync(id, item, ct);
        }

        public async Task<bool> Delete(uint id, CancellationToken ct)
        {
            return await _personRepository.DeleteAsync(id, ct);
        }
    }
}
