using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmallShop.Contracts.Persistence;
using SmallShop.Infrastructure.Persistence.Common;
using SmallShop.Infrastructure.Persistence.DatabaseContext;
using SmallShop.Infrastructure.Persistence.ProductAgg;

namespace SmallShop.Infrastructure.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SmallShopContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("SmallShopDb"));
        });

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
