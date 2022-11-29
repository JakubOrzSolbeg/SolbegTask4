using DataRepository.DbContext;

namespace DataRepository.Repositories;

public abstract class Repository
{
    protected readonly MainDbContext MainDbContext;

    public Repository(MainDbContext mainDbContext)
    {
        MainDbContext = mainDbContext;
    }

    public async Task Commit()
    {
        await MainDbContext.SaveChangesAsync();
    }
}