using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class NewMovieDto
{
    [MaxLength(128)]
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    [MaxLength(128)]
    public string Author { get; set; } = null!;
}