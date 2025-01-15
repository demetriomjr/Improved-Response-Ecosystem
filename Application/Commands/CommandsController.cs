using Application.Commands.People;

namespace Application.Commands
{
    public class CommandsController
    {
        private readonly IPersonRepository _personRepository;

        public CommandsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            People = new PeopleCommandsController(_personRepository);
        }

        public PeopleCommandsController People { get; }
    }
}
