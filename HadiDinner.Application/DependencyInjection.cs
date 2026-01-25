using FluentValidation;
using HadiDinner.Application.Authentication.Commands.Register;
using HadiDinner.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HadiDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
        );
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehavior<,>));
        services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();
        return services;
    }
}
