using DataRepository3.DbContext;
using DataRepository3.Entities;
using DataRepository3.Repositories;
using DataRepository3.Repositories.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataRepository3;

public static class Setup
{
    public static IServiceCollection AddDataRepository(this IServiceCollection services)
    {
        services.AddDbContext<MainDbContext1>();
        services.AddScoped<Repository<Movie>, MovieRepository>();
        return services;
    }
}