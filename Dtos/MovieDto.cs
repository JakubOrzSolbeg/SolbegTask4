using System.ComponentModel.DataAnnotations;

namespace Backend;

public class MovieDto
{
    public int MovieId { get; set; }
    [MinLength(3)]
    [MaxLength(128)]
    public string Name { get; set; } = null!;
    public bool IsWatched { get; set; } = false;
    [MinLength(3)]
    [MaxLength(128)]
    public string Author { get; set; } = null!;
}