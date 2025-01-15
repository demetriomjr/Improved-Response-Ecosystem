using Application.Interfaces.Repositories;
using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DIExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
