using HadiDinner.Api.Common.Errors;
using HadiDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HadiDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMapster();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, HadiDinnerProblemDetailsFactory>();

        return services;
    }
}
