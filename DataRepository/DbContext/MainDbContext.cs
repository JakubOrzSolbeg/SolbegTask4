using Microsoft.EntityFrameworkCore;

namespace DataRepository.DbContext;

public class MainDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private IConfiguration _configuration;
    public MainDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("MainDb"));
        
    }
}