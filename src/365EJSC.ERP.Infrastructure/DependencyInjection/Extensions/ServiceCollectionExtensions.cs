using _365EJSC.ERP.Infrastructure.Abstractions;
using _365EJSC.ERP.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace _365EJSC.ERP.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddConfigInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();
            return services;
        }
    }
}
