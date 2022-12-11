using Backend.Services.Interfaces;
using DataRepository3.Entities;
using DataRepository3.Repositories;
using Dtos;

namespace Backend.Services.Implementations;

public class MovieService2 : IMovieService
{
    private readonly Repository<Movie> _movieRepository;
    
    public MovieService2(Repository<Movie> movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public async Task<List<MovieDto>> GetAllMovies()
    {
        return (await _movieRepository.GetAll()).Select(m => new MovieDto()
        {
            Author = m.Author,
            IsWatched = m.IsWatched,
            Name = m.Name,
            MovieId = m.Id
        }).ToList();
    }

    public async Task<MovieDto?> GetMovieById(int movieId)
    {
        var movie = await _movieRepository.GetById(movieId);
        if (movie == null)
        {
            return null;
        }

        return new MovieDto()
        {
            Author = movie.Author,
            Name = movie.Name,
            IsWatched = movie.IsWatched,
            MovieId = movie.Id
        };

    }

    public async Task<bool> AddMovie(NewMovieDto newMovie)
    {
        var movieEntity = new Movie()
        {
            Author = newMovie.Author,
            Name = newMovie.Name,
            IsWatched = false
        };

        await _movieRepository.Add(movieEntity);
        return true;
    }

    public async Task<bool> EditMovie(int movieId, NewMovieDto movie)
    {
        var movieEntity = await _movieRepository.GetById(movieId);
        if (movieEntity == null)
        {
            return false;
        }

        movieEntity.Author = movie.Author;
        movieEntity.Name = movie.Name;

        await _movieRepository.Save(movieEntity);
        return true;
    }

    public async Task<bool> SwapMovies(int movieAId, int movieBId)
    {
        var movieEntityA = await _movieRepository.GetById(movieAId);
        var movieEntityB = await _movieRepository.GetById(movieBId);
        if (movieEntityA == null || movieEntityB == null)
        {
            return false;
        }

        var movieAOrder = movieEntityA.OrderNumber;
        var movieBOrder = movieEntityB.OrderNumber;

        movieEntityA.OrderNumber = movieBOrder;
        movieEntityB.OrderNumber = movieAOrder;

        await _movieRepository.Save(movieEntityA);
        await _movieRepository.Save(movieEntityB);

        return true;
    }

    public async Task<bool> MarkAsRead(int movieId)
    {
        var movieEntity = await _movieRepository.GetById(movieId);
        if (movieEntity == null)
        {
            return false;
        }

        movieEntity.IsWatched = true;
        await _movieRepository.Save(movieEntity);
        return true;
    }

    public async Task<bool> RemoveMovie(int movieId)
    {
        var movieEntity = await _movieRepository.GetById(movieId);
        if (movieEntity == null)
        {
            return false;
        }

        await _movieRepository.Delete(movieEntity);
        return true;
    }

    public async Task<bool> RearrangeMovies(List<int> orderList)
    {
        var movies = await _movieRepository.GetAll();
        var moviesDict = movies.ToDictionary(movie => movie.Id);
        orderList.Reverse();

        int i = 1;
        if (orderList.Count < movies.Count)
        {
            return false;
        }
        
        foreach (var movieId in orderList)
        {
            moviesDict[movieId].OrderNumber = i++;
        }

        await _movieRepository.Commit();
        return true;
    }
}