using DataRepository.Repositories.Interfaces;
using Requests;

namespace DataRepository3.Repositories.Implementations;

public class MovieRepository : IMovieRepository
{
    public async Task AddMovie(NewMovie newMovie)
    {
        throw new NotImplementedException();
    }

    public async Task EditMovie(int movieId, NewMovie editedMovie)
    {
        throw new NotImplementedException();
    }

    public async Task MarkAsRead(int movieId)
    {
        throw new NotImplementedException();
    }

    public async Task SwapOrder(int idMovieA, int idMovieB)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveMovie(int movieId)
    {
        throw new NotImplementedException();
    }
}