using HadiDinner.Application.Common.Interfaces.Services;

namespace HadiDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
