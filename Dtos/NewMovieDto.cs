using System.ComponentModel.DataAnnotations;

namespace Backend;

public class NewMovieDto
{
    [MinLength(3)]
    [MaxLength(128)]
    public string Name { get; set; } = null!;
    [MinLength(3)]
    [MaxLength(128)]
    public string Author { get; set; } = null!;
}