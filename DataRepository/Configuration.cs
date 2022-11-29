using DataRepository.DbContext;

namespace DataRepository;

public class Configuration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MainDbContext>();
    }
}