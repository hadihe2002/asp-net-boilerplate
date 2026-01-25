using ErrorOr;
using HadiDinner.Domain.Common.Models;
using HadiDinner.Domain.Dinner.ValueObjects;
using HadiDinner.Domain.Host.ValueObjects;
using HadiDinner.Domain.Menu.Entities;
using HadiDinner.Domain.Menu.ValueObjects;
using HadiDinner.Domain.MenuReview.ValueObjects;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _reviewIds = new();
    public string Name { get; }

    public string Description { get; }

    public string AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> ReviewIds => _reviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static ErrorOr<Menu> Create(string name, string description, HostId hostId)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            createdDateTime: DateTime.UtcNow,
            updatedDateTime: DateTime.UtcNow
        );
    }
}
