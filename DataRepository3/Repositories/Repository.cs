using DataRepository3.DbContext;

namespace DataRepository3.Repositories;

public abstract class Repository
{
    protected readonly MainDbContext1 MainDbContext;

    public Repository(MainDbContext1 mainDbContext)
    {
        MainDbContext = mainDbContext;
    }

    public async Task Commit()
    {
        await MainDbContext.SaveChangesAsync();
    }
}