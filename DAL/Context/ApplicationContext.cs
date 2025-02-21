using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public sealed class ApplicationContext : IdentityDbContext<User>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().Ignore(c => c.AccessFailedCount);
        modelBuilder.Entity<User>().Ignore(c => c.LockoutEnabled);
        modelBuilder.Entity<User>().Ignore(c => c.LockoutEnd);
        modelBuilder.Entity<User>().Ignore(c => c.PhoneNumber);
        modelBuilder.Entity<User>().Ignore(c => c.PhoneNumberConfirmed);
        modelBuilder.Entity<User>().Ignore(c => c.TwoFactorEnabled);
        modelBuilder.Entity<User>().Ignore(c => c.EmailConfirmed);
    }
}