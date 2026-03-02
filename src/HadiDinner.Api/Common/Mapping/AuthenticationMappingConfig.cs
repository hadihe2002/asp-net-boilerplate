namespace HadiDinner.Api.Common.Mapping;

using HadiDinner.Application.Authentication.Commands.Register;
using HadiDinner.Application.Authentication.Common;
using HadiDinner.Application.Authentication.Queries.Login;
using HadiDinner.Contracts.Authentication;
using Mapster;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config
            .NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);
    }
}
