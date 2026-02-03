using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procat.UsersModule.Models;

namespace Procat.UsersModule.Persistence.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Email, "IX_Users_Email")
            .IsUnique();
        
        builder.HasIndex(x => x.PhoneNumber, "IX_Users_PhoneNumber")
            .IsUnique();
    }
}