using Application.Interfaces;
using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Models.People;

namespace Application
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddInternalRepositories(this IServiceCollection services)
        {
            services.AddKeyedScoped<IRepository<Person>, CommandRepository<Person>>("peopleQuery");
            services.AddKeyedScoped<IRepository<Person>, QueryRepository<Person>>("peopleCommand");

            return services;
        }
    }
}
