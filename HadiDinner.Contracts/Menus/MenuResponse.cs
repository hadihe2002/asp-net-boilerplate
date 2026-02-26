namespace HadiDinner.Contracts.Menus;

public record MenuResponse(
    string Id,
    string Name,
    string Description,
    double? AverageRating,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime,
    List<MenuSectionResponse> Sections
);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> Items
);

public record MenuItemResponse(string Id, string Name, string Description);
