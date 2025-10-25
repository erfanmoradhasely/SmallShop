using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmallShop.Application;
using SmallShop.Infrastructure;
using SmallShop.Infrastructure.Identity;
using SmallShop.Infrastructure.Persistence;

namespace SmallShop.Config;

public static class SmallShopServiceRegistration
{
    public static IServiceCollection AddSmallShopServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices();
        services.AddQueryServices();
        services.AddInfrastructureServices();
        services.AddIdentityServices(configuration);
        services.AddPersistenceServices(configuration);

        return services;
    }
}
