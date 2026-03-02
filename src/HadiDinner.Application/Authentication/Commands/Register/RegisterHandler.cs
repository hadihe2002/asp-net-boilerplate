using ErrorOr;
using HadiDinner.Application.Authentication.Common;
using HadiDinner.Application.Common.Interfaces.Authentication;
using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Domain.Common.Errors;
using HadiDinner.Domain.User;
using MediatR;

namespace HadiDinner.Application.Authentication.Commands.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken
    )
    {
        var (firstName, lastName, email, password) = command;

        if (_userRepository.GetUserByEmail(email) is not null)
            return Errors.User.DuplicateEmail;

        ErrorOr<User> userResult = User.Create(firstName, lastName, email, password);
        if (userResult.IsError)
            return userResult.Errors;
        var user = userResult.Value;

        _userRepository.Add(user);

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
