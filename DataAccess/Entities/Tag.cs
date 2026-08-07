using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models.Enums;

namespace DataAccess.Entities;

[Table("Tags")]
public class Tag
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] public string Name { get; set; }

    public TagCategory Category { get; set; } // genre, theme, mood, character_type

    [MaxLength(300)] public string Description { get; set; }

    public List<Title> Titles { get; set; } = new();
}