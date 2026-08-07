using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Enums;

namespace DataAccess.Entities;

[Table("Titles")]
public class Title
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public ContentType ContentType { get; set; }

    [Required] public string OriginalName { get; set; }

    [Required] public string RussianName { get; set; }

    [Required] public string EnglishName { get; set; }

    public string? Country { get; set; }

    public string Author { get; set; }

    [MaxLength(300)] public string Description { get; set; }

    public ReadingStatus Status { get; set; }

    public int MyRating { get; set; } // 0-10

    public int? TotalUnits { get; set; } // всего глав/томов/серий

    public int CompletedUnits { get; set; } // сколько прочитано/просмотрено
}