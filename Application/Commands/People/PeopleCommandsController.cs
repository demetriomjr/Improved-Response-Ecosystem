namespace Application.Commands.People
{
    public class PeopleCommandsController
    {
        private readonly IPersonRepository _personRepository;

        public PeopleCommandsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
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

            Person? person = await _personRepository.GetById(id);
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
