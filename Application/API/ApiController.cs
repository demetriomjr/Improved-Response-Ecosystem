using Application.API.People;
using Application.API.Repositories;
using Application.Interfaces;


namespace Application.API
{
    public class ApiController
    {
        private static readonly IDataManagementRepository _personRepository = new ApiPersonRepository();

        public PeopleController People = new(_personRepository);
    }
}
