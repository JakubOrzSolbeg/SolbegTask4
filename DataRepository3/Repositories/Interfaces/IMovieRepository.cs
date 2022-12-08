

using Requests;

namespace DataRepository.Repositories.Interfaces;

public interface IMovieRepository
{
    public Task AddMovie(NewMovie newMovie);
    public Task EditMovie(int movieId, NewMovie editedMovie);
    public Task MarkAsRead(int movieId);
    public Task SwapOrder(int idMovieA, int idMovieB);
    public Task RemoveMovie(int movieId);

}