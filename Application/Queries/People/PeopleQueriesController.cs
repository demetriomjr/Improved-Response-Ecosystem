namespace Application.Queries.People
{
    public class PeopleQueriesController
    {
        private readonly IPersonRepository _personRepository;

        public PeopleQueriesController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetAsync()
        {
            return await _personRepository.GetAll();
        }

        public async Task<Person> GetAsync(uint id)
        {
            return await _personRepository.GetById(id);
        }
    }
}
