using Application.Commands;
using Application.Queries;

namespace Application
{
    public static class ApplicationController
    {
        public static CommandsController Commands = new();
        public static QueriesController Queries = new();
    }
}
