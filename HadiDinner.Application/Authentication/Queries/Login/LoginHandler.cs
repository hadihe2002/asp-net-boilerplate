using ErrorOr;
using HadiDinner.Application.Authentication.Common;
using HadiDinner.Application.Authentication.Queries.Login;
using HadiDinner.Application.Common.Interfaces.Authentication;
using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Domain.Common.Errors;
using HadiDinner.Domain.User;
using MediatR;

public class LoginHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        LoginQuery query,
        CancellationToken cancellationToken
    )
    {
        var (email, password) = query;

        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!user.VerifyPassword(password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
