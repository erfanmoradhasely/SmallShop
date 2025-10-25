using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop.Application;

public static class QueryServiceRegistration
{
    public static IServiceCollection AddQueryServices(this IServiceCollection services)
    {
        services.AddAutoMapper(_ => { }, Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
