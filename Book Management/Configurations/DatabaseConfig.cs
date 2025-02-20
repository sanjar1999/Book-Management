using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Book_Management.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}
