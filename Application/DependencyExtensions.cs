using Application.Interfaces;
using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddInternalRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, ApiPersonRepository>();
            services.AddScoped<IPersonRepository, QueryRepository>();

            return services;
        }
    }
}
