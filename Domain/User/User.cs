using Domain.Primitives;

namespace Domain.User;

public sealed class User : Entity
{
    public UserId Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
