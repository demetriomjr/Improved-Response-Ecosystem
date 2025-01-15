using Models.People;

namespace Application.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        //TO BE REPLACED WITH REAL LOGIC
        private List<Person> _people = new List<Person>();

        public Task<List<Person>> GetAll()
        {
            return Task.FromResult(_people);
        }

        public Task<Person> GetById(uint id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(person!);
        }

        public Task<bool> CreatePerson(Person person)
        {
            _people.Add(person);
            return Task.FromResult(true);
        }

        public Task<bool> DeletePerson(uint id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _people.Remove(person);
                return Task.FromResult(true);
            }
            else return Task.FromResult(false);
        }

        public Task<bool> UpdatePerson(uint id, Person person)
        {
            var existingPerson = _people.FirstOrDefault(p => p.Id == id);

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
