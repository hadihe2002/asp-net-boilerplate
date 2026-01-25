using System.Numerics;

namespace HadiDinner.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    protected AggregateRoot(TId id)
        : base(id) { }
}
