using DataRepository3.DbContext;
using DataRepository3.Entities;

namespace DataRepository3.Repositories;

public abstract class Repository<T> where T : BaseEntity
{
    protected readonly MainDbContext1 MainDbContext;

    public Repository(MainDbContext1 mainDbContext)
    {
        MainDbContext = mainDbContext;
    }

    public abstract Task<List<T>> GetAll();
    public abstract Task<T?> GetById(int id);
    public abstract Task<T> Add(T obj);
    public abstract Task<T> Save(T obj);
    public abstract Task<bool> Delete(T obj);

    public async Task Commit()
    {
        await MainDbContext.SaveChangesAsync();
    }
}