namespace Procat.UsersModule.Models;

public class User
{
    public string Id { get; init; } = Ulid.NewUlid().ToString();

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public required string LicenceUrl { get; set; }

    public required string PassportUrl { get; set; }

    public required string InternationalDrivingPermitUrl { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public ICollection<Role> Roles { get; private set; } = [];
}
