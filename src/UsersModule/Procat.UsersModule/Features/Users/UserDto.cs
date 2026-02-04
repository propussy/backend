namespace Procat.UsersModule.Features.Users;

public sealed record UserDto(
    string Id,
    string Email,
    string PhoneNumber,
    string FirstName,
    string LastName,
    DateTime BirthDate,
    string LicenceUrl,
    string PassportUrl,
    string InternationalDrivingPermitUrl,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt
);
