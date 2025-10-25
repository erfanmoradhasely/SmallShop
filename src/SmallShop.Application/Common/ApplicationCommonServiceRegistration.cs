using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmallShop.Application.Common.Validation;

namespace SmallShop.Application.Common;

public static class ApplicationCommonServiceRegistration
{
    public static void AddApplicationCommonServices(this IServiceCollection service)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
    }
}