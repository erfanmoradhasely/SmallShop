using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using SmallShop.Application.Common;
using SmallShop.Domain.ProductAgg.Services;
using SmallShop.Application.Products;


namespace SmallShop.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddApplicationCommonServices();

        services.AddAutoMapper(_ => { }, Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient<IProductDomainService,ProductDomainService>();

        return services;
    }
}
