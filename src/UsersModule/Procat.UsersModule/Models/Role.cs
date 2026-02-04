namespace Procat.UsersModule.Models;

public class Role
{
    public string Id { get; init; } = Ulid.NewUlid().ToString();
    
    public required string Name { get; set; }

    public ICollection<User> Users { get; private set; } = [];
}