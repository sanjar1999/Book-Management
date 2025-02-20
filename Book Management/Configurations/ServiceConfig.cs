using Application.Interfaces;
using Application.Services;

namespace Book_Management.Configurations;

public static class ServiceConfig
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
    }
}
