using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Procat.UsersModule.Persistence;

namespace Procat.UsersModule;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUsersModule(IConfiguration configuration)
        {
            services.AddDbContext<UsersDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("user-module"))
            );

            services.AddMediatR(options =>
                options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly)
            );

            return services;
        }
    }

    extension(WebApplication app)
    {
        public void UseUsersModule()
        {
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<UsersDbContext>();

            context.Database.Migrate();
        }
    }
}
