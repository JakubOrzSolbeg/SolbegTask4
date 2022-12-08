using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataRepository3.DbContext;

public class MainDbContext1 : Microsoft.EntityFrameworkCore.DbContext
{
    private IConfiguration _configuration;
    public MainDbContext1(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("MainDb"));
    }
}