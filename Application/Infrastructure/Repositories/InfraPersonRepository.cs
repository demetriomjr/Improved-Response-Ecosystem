using Application.Interfaces;
using Models.People;

namespace Application.Infrastructure.Repositories
{
    public class InfraPersonRepository : IDataManagementRepository<Person>
    {
        //TO BE REPLACED WITH REAL LOGIC
        private List<Person> _peopleList = new List<Person>();

        public Task<List<Person>> GetAllAsync(Func<Person, bool> predicate, CancellationToken ct)
        {
            return Task.FromResult(_peopleList);
        }

        public Task<Person?> GetByIdAsync(uint id, CancellationToken ct)
        {
            var result = _peopleList.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(result);
        }

        public Task<Person?> CreateAsync(Person? person, CancellationToken ct)
        {
            _peopleList.Add(person ??= new());
            return Task.FromResult<Person?>(person);
        }

        public Task<bool> DeleteAsync(uint id, CancellationToken ct)
        {
            var person = _peopleList.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _peopleList.Remove(person);
                return Task.FromResult(true);
            }
            else return Task.FromResult(false);
        }

        public Task<bool> UpdateAsync(uint id, Person? person, CancellationToken ct)
        {
            var existingPerson = _peopleList.FirstOrDefault(p => p.Id == id);

            if (existingPerson != null)
            {
                foreach (var property in typeof(Person).GetProperties())
                {
                    var newValue = property.GetValue(person);
                    property.SetValue(existingPerson, newValue);
                }
                return Task.FromResult(true);
            }
            else return Task.FromResult(false);
        }
    }
}
