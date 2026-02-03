using Microsoft.EntityFrameworkCore;

namespace Procat.UsersModule.Persistence;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options) { }
