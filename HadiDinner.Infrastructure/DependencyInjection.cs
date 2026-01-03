using HadiDinner.Application.Common.Interfaces.Authentication;
using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Application.Common.Interfaces.Services;
using HadiDinner.Infrastructure.Authentication;
using HadiDinner.Infrastructure.Persistence;
using HadiDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HadiDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
