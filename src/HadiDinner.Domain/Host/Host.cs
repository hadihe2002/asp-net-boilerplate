using HadiDinner.Domain.Common.Models;
using HadiDinner.Domain.Common.ValueObjects;
using HadiDinner.Domain.Host.ValueObjects;
using HadiDinner.Domain.User.ValueObjects;

namespace HadiDinner.Domain.Host;

public class Host : AggregateRoot<HostId>
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string ProfileImage { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public UserId UserId { get; }

    public DateTime CreateDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    private Host(
        HostId id,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        CreateDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(string firstName, string lastName, string profileImage, UserId userId)
    {
        return new Host(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
