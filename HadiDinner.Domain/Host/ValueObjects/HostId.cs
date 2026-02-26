using HadiDinner.Domain.Common.Models;

namespace HadiDinner.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid hostId)
    {
        Value = hostId;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HostId Create(string hostId)
    {
        return new(Guid.Parse(hostId));
    }

    public static HostId Create(Guid hostId)
    {
        return new(hostId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
