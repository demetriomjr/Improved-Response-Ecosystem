using Models.People;

namespace Application.Queries.People
{
    public class PeopleQueriesController
    {
        public List<Person> Get()
        {
            return [];
        }

        public Person Get(uint id)
        {
            return new();
        }
    }
}
