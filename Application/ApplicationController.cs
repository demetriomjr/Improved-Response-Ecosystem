global using Application.Commands;
global using Application.Interfaces.Repositories;
global using Application.Queries;
global using Application.Repositories;
global using Models.People;

namespace Application
{
    public static class ApplicationController
    {
        private static readonly IPersonRepository _personRepository = new PersonRepository();
        public static CommandsController Commands = new(_personRepository);
        public static QueriesController Queries = new(_personRepository);
    }
}
