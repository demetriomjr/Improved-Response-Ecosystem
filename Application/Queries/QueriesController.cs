using Application.Interfaces.Repositories;
using Application.Queries.People;

namespace Application.Queries
{
    public class QueriesController
    {
        private readonly IPersonRepository _personRepository;

        public QueriesController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            People = new PeopleQueriesController(_personRepository);
        }

        public PeopleQueriesController People { get; }
    }
}
