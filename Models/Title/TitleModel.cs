using Models.Enums;

namespace Models;

public record TitleModel
{
    public Guid Id { get; init; }

    public ContentType ContentType { get; init; }

    public string OriginalName { get; init; }

    public string RussianName { get; init; }

    public string EnglishName { get; init; }

    public string? Country { get; init; }

    public string Author { get; init; }

    public string Description { get; init; }

    public ReadingStatus Status { get; init; }

    public int MyRating { get; init; }

    public int? TotalUnits { get; init; }

    public int CompletedUnits { get; init; }
}