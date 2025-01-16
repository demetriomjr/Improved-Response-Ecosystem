using Application.API.People;
using Application.API.Repositories;
using Application.Interfaces;
using Models.People;


namespace Application.API
{
    public class ApiController
    {
        private static readonly IDataManagementRepository<Person> _personRepository = new ApiPersonRepository();

        public PeopleController People = new(_personRepository);
    }
}
