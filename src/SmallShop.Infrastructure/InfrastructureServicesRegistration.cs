using Microsoft.Extensions.DependencyInjection;
using SmallShop.Contracts.Logging;
using SmallShop.Infrastructure.Logging;

namespace SmallShop.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}