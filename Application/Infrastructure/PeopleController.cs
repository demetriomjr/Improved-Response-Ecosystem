using Application.Interfaces;
using Models.People;
using Predicate = System.Func<Models.People.Person, bool>;

namespace Application.Infrastructure
{
    public class PeopleController : IWebAPIContext<Person>
    {
        private IRepository<Person> _personRepository;

        public PeopleController(IRepository<Person> repository)
        {
            _personRepository = repository;
        }

        public async Task<List<Person>> Get(Predicate predicate, CToken ct)
        {
            return await _personRepository.GetAllAsync(predicate, ct);
        }
        public async Task<Person?> Get(uint id, CToken ct)
        {
            return await _personRepository.GetByIdAsync(id, ct);
        }

        public async Task<Person> Post(Person item, CToken ct)
        {
            if (item.Id > 0)
            {
                await _personRepository.UpdateAsync(item, ct);
                return item;
            }

            return await _personRepository.CreateAsync(item, ct);
        }
        public async Task<bool> Put(Person item, CToken ct)
       {
            switch (item.CreatedAt)
            {
                case null:
                    return await _personRepository.CreateAsync(item, ct) != null;
                default:
                    return await _personRepository.UpdateAsync(item, ct);
            }
        }

        public async Task<bool> Delete(uint id, CToken ct)
        {
            if (id <= 0) return false;
            return await _personRepository.DeleteAsync(id, ct);
        }
    }
}
