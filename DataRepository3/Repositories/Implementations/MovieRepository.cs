using DataRepository3.DbContext;
using DataRepository3.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataRepository3.Repositories.Implementations;

public class MovieRepository : Repository<Movie>
{
    public MovieRepository(MainDbContext1 mainDbContext) : base(mainDbContext)
    {
    }
    
    public override async Task<List<Movie>> GetAll()
    {
        return await MainDbContext.Movies
            .OrderBy(movie => movie.IsWatched)
            .ThenByDescending(movie => movie.OrderNumber)
            .ToListAsync();
    }

    public override async Task<Movie?> GetById(int id)
    {
        return await MainDbContext.Movies.Where(movie => movie.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public override async Task<Movie> Add(Movie obj)
    {
        await MainDbContext.Movies.AddAsync(obj);
        await Commit();
        return obj;
    }

    public override async Task<Movie> Save(Movie obj)
    {
        MainDbContext.Movies.Update(obj);
        await Commit();
        return obj;
    }

    public override async Task<bool> Delete(Movie obj)
    {
        MainDbContext.Movies.Remove(obj);
        await Commit();
        return true;
    }
}