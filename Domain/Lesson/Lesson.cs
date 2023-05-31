using Domain.Chapter;
using Domain.Primitives;

namespace Domain.Lesson;

public sealed class Lesson : Entity
{
    public LessonId Id { get; set; }

    public ChapterId ChapterId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Uri VideoUrl { get; set; }

    public int LessonNumber { get; set; }
}
