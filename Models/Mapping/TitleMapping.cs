using DataAccess.Entities;

namespace Models.Mapping;

public static class TitleMapping
{
    public static TitleModel MapToCurveModel(this Title title)
    {
        return new TitleModel
        {
            Id = title.Id,
            ContentType = title.ContentType,
            OriginalName = title.OriginalName,
            RussianName = title.RussianName,
            EnglishName = title.EnglishName,
            Country = title.Country,
            Author = title.Author,
            Description = title.Description,
            Status = title.Status,
            MyRating = title.MyRating,
            TotalUnits = title.TotalUnits,
            CompletedUnits = title.CompletedUnits,
        };
    }
}