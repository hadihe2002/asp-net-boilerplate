using System.Numerics;

namespace HadiDinner.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    where TId : notnull
{
    protected AggregateRoot(TId id)
        : base(id) { }

    protected AggregateRoot() { }
}
