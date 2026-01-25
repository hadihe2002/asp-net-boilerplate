using ErrorOr;

namespace HadiDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail =>
            Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email Already Exists for this Email"
            );

        public static Error InvalidInput =>
            Error.Validation(code: "User.InvalidInput", description: "Input is not valid");

        public static Error InvalidEmailFormat =>
            Error.Validation(
                code: "User.InvalidEmailFormat",
                description: "Email format is not valid"
            );

        public static Error WeakPassword =>
            Error.Validation(code: "User.WeakPassword", description: "Password is weak");
    }
}
