using DataRepository3.Entities;
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

    public DbSet<Movie> Movies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.Entity<Movie>().HasData(
            new Movie()
            {
                Id = 1,
                Author = "Technoblade",
                Name = "How to obliterate orphans"
            },
            new Movie()
            {
                Id = 2,
                Author = "Peter Jackson",
                Name = "Pirates from Caraibes"
            },
            new Movie()
            {
                Id = 3,
                Author = "George Lucas",
                Name = "Star Wars IV New Hope"
            },
            new Movie()
            {
                Id = 4,
                Author = "George Lucas",
                Name = "Star Wars V Emire Strikes Back"
            },
            new Movie()
            {
                Id = 5,
                Author = "Dave Filoni",
                Name = "The Mandalorian"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("MainDb"), 
            b => b.MigrationsAssembly(_configuration["MigrationAssembly"]));
    }
}