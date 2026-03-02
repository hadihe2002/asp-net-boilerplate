using ErrorOr;
using HadiDinner.Domain.Common.Models;
using HadiDinner.Domain.Dinner.ValueObjects;
using HadiDinner.Domain.Guest.ValueObjects;
using HadiDinner.Domain.Host.ValueObjects;
using HadiDinner.Domain.Menu.ValueObjects;
using HadiDinner.Domain.MenuReview.ValueObjects;

namespace HadiDinner.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public int Rating { get; private set; }

    public string Comment { get; private set; }

    public HostId HostId { get; private set; }

    public MenuId MenuId { get; private set; }
    public GuestId GuestId { get; private set; }
    public DinnerId DinnerId { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private MenuReview(
        MenuReviewId menuReviewId,
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        GuestId = guestId;
        DinnerId = dinnerId;
        MenuId = menuId;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static ErrorOr<MenuReview> Create(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId
    )
    {
        return new MenuReview(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId,
            createdDateTime: DateTime.UtcNow,
            updatedDateTime: DateTime.UtcNow
        );
    }
}
