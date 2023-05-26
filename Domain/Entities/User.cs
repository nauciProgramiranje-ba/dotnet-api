using Domain.Primitives;

namespace Domain.Entities;

public sealed class User : Entity
{
    private User(Guid id, string name, string email) 
        : base(id)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }

    public string Email { get; set; }
}
