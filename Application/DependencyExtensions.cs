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
            // Adicionando o using necessário dentro do método
            {
                services.AddScoped<IPersonRepository, ApiPersonRepository>();
                services.AddScoped<IPersonRepository, InfraPersonRepository>();
            }

            return services;
        }
    }
}
