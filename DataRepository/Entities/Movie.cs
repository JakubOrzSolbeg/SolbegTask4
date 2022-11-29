namespace DataRepository.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsWatched { get; set; } = false;
    public string Author { get; set; } = null!;
    public bool IsFavourite { get; set; }
    // For changing positions 
    public int IdBefore { get; set; } = 0;
}