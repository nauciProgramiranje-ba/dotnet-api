using Domain.Primitives;

namespace Domain.Entities;

public sealed class Lesson : Entity
{
    public Lesson(Guid id, Chapter chapter, string title, string description, Uri videoUrl) 
        : base(id)
    {
        Chapter = chapter;
        Title = title;
        Description = description;
        VideoUrl = videoUrl;
    }

    public Chapter Chapter { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Uri VideoUrl { get; set; }
}
