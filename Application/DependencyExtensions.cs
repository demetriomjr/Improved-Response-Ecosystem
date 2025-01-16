using Application.API.Repositories;
using Application.Infrastructure.Repositories;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddInternalRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDependencyRepository, ApiPersonRepository>();
            services.AddScoped<IDependencyRepository, InfraPersonRepository>();

            return services;
        }
    }
}
