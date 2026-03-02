using ErrorOr;

namespace HadiDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials =>
            Error.Validation("InvalidCredentials", "Invalid Credentials");
    }
}
