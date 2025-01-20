using Application.Interfaces;
using Models.People;

namespace Application.Infrastructure
{
    public class InfrastructureController
    {
        public QueryController Query = new();
        public CommandController Command = new();
    }
}
