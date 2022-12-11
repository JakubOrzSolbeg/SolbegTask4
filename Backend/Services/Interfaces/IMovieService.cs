namespace Backend.Services.Interfaces;

using Dtos;

public interface IMovieService
{
    public Task<List<MovieDto>> GetAllMovies();
    public Task<MovieDto?> GetMovieById(int movieId);
    public Task<bool> AddMovie(NewMovieDto newMovie);
    public Task<bool> EditMovie(int movieId, NewMovieDto movie);
    public Task<bool> SwapMovies(int movieAId, int movieBId);
    public Task<bool> MarkAsRead(int movieId);
    public Task<bool> RemoveMovie(int movieId);
    public Task<bool> RearrangeMovies(List<int> orderList);
}