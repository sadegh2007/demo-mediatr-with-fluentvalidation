using System.Reflection;
using DemoMediatRWithFluentValidation.Common;
using DemoMediatRWithFluentValidation.Common.Behaviors;
using FluentValidation;

namespace DemoMediatRWithFluentValidation.Configurations;

public static class ServicesConfigurations
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<AppExceptionHandler>();
            
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);

            cfg.AddOpenBehavior(typeof(LogPipeline<,>));
            cfg.AddOpenBehavior(typeof(ValidationPipeline<,>));
        });
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}