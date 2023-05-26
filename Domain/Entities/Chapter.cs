using Domain.Primitives;

namespace Domain.Entities;

public sealed class Chapter : Entity
{
    public Chapter(Guid id, string title, string description) 
        : base(id)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; }

    public string Description { get; set; }
}
