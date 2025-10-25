using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmallShop.Application.Common.Validation;

namespace SmallShop.Application.Common;

public class ApplicationCommonServiceRegistration
{
    public static void Init(IServiceCollection service)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
    }
}