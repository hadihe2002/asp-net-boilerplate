using ErrorOr;

namespace HadiDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Menu
    {
        public static Error DuplicateName =>
            Error.Conflict("Menu.DuplicateName", "This Menu Name Does Already Exists");
    }
}
