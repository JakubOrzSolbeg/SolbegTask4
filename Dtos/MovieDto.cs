using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class MovieDto
{
    [Required]
    public int MovieId { get; set; }
    [Required]
    [MaxLength(128)]
    public string Name { get; set; } = null!;
    [Required]
    public bool IsWatched { get; set; } = false;
    [Required]
    [MaxLength(128)]
    public string Author { get; set; } = null!;
}