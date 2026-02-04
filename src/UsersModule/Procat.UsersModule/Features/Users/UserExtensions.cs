using Procat.UsersModule.Models;

namespace Procat.UsersModule.Features.Users;

public static class UserExtensions
{
    extension(User u)
    {
        public UserDto ToDto()
        {
            return new UserDto(
                u.Id,
                u.Email,
                u.PhoneNumber,
                u.FirstName,
                u.LastName,
                u.BirthDate,
                u.LicenceUrl,
                u.PassportUrl,
                u.InternationalDrivingPermitUrl,
                u.CreatedAt,
                u.UpdatedAt
            );
        }
    }
    
    extension(IQueryable<User> users)
    {
        public IQueryable<UserDto> ToDto()
        {
            return users.Select(u => u.ToDto());
        }
    }
}
