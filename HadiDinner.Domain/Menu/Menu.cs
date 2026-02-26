using ErrorOr;
using HadiDinner.Domain.Common.Models;
using HadiDinner.Domain.Common.ValueObjects;
using HadiDinner.Domain.Dinner.ValueObjects;
using HadiDinner.Domain.Host.ValueObjects;
using HadiDinner.Domain.Menu.Entities;
using HadiDinner.Domain.Menu.ValueObjects;
using HadiDinner.Domain.MenuReview.ValueObjects;

namespace HadiDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _reviewIds = new();
    public string Name { get; private set; }

    public string Description { get; private set; }

    public AverageRating AverageRating { get; private set; } = AverageRating.Create();

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> ReviewIds => _reviewIds.AsReadOnly();

    public HostId HostId { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private Menu() { }

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

    public void AddSections(List<MenuSection> sections)
    {
        _sections.AddRange(sections);
    }

    public void AddSection(MenuSection section)
    {
        _sections.Add(section);
    }
}
