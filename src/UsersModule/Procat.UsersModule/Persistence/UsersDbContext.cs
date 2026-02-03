using Microsoft.EntityFrameworkCore;
using Procat.UsersModule.Models;

namespace Procat.UsersModule.Persistence;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    public DbSet<User>  Users { get; set; }
    
    public DbSet<Role>  Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDbContext).Assembly);
    }
}
