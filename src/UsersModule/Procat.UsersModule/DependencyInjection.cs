using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Procat.UsersModule.Persistence;

namespace Procat.UsersModule;

public static class DependencyInjection
{
    extension (IServiceCollection services) {
        public IServiceCollection AddDbContext(IConfiguration configuration)
        {
            return services.AddDbContext<UsersDbContext>(options => options.UseNpgsql());
        }
    }
}