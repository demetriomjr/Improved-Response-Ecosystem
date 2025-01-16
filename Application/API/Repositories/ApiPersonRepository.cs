using Application.Interfaces;
using Models.People;
using RabbitHelper;
using System.Text.Json;

namespace Application.API.Repositories
{
    public class ApiPersonRepository : IDataManagementRepository<Person>
    {

        //TO BE REPLACED WITH REAL LOGIC
        private List<Person> _people = new List<Person>();

        public ApiPersonRepository()
        { 
                RabbitHelperService.Init().Wait();
        }

        public async Task<List<Person>> GetAllAsync(Func<Person?, bool> predicate, CancellationToken ct)
        {
            var body = JsonSerializer.Serialize(predicate);
            await RabbitHelperService.PublishOnQueueAsync<Person>(predicate, async(byte[] result) =>
            {

            });
        }

        public Task<Person?> GetByIdAsync(uint id, CancellationToken ct)
        {
            var result = _people.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(result);
        }

        public Task<Person?> CreateAsync(Person? person, CancellationToken ct)
        {
            _people.Add(person ??= new());
            return Task.FromResult<Person?>(person);
        }

        public Task<bool> DeleteAsync(uint id, CancellationToken ct)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _people.Remove(person);
                return Task.FromResult(true);
            }
            else return Task.FromResult(false);
        }

        public Task<bool> UpdateAsync(uint id, Person? item, CancellationToken ct)
        {
            var existingPerson = _people.FirstOrDefault(p => p.Id == id);

            if (existingPerson != null)
            {
                foreach (var property in typeof(Person).GetProperties())
                {
                    var newValue = property.GetValue(item);
                    property.SetValue(existingPerson, newValue);
                }
                return Task.FromResult(true);
            }
            else return Task.FromResult(false);
        }
    }
}
