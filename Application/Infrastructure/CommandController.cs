using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models.People;

namespace Application.Infrastructure
{
    public class CommandController
    {
        public PeopleController People([FromKeyedServices("peopleCommand")] IRepository<Person> repository) => new PeopleController(repository);
    }
}
