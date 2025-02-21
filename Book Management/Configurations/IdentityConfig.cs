using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace Book_Management.Configurations;

public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();
    }
}
