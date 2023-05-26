namespace Domain.User;

public class User
{
    public UserId Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
