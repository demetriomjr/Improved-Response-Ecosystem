using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models.People;

namespace Application.Infrastructure
{
    public class QueryController
    {
        public PeopleController People([FromKeyedServices("peopleQuery")] IRepository<Person> repository) => new PeopleController(repository);
    }
}
