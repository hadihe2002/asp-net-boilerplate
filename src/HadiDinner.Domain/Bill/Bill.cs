using ErrorOr;
using HadiDinner.Domain.Bill.ValueObjects;
using HadiDinner.Domain.Common.Models;
using HadiDinner.Domain.Dinner.ValueObjects;
using HadiDinner.Domain.Guest.ValueObjects;
using HadiDinner.Domain.Host.ValueObjects;

namespace HadiDinner.Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public DinnerId DinnerId { get; }

    public GuestId GuestId { get; }

    public HostId HostId { get; }

    public Price Price { get; }

    private Bill(
        BillId id,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price
    )
        : base(id)
    {
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
    }

    public static ErrorOr<Bill> Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price
    )
    {
        return new Bill(
            BillId.CreateUnique(),
            createdDateTime: DateTime.UtcNow,
            updatedDateTime: DateTime.UtcNow,
            dinnerId,
            guestId,
            hostId,
            price
        );
    }
}
