using Domain.Chapter;
using Domain.Lesson;

namespace Domain.Lesson;

public class Lesson 
{
    public LessonId Id { get; set; }

    public ChapterId ChapterId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Uri VideoUrl { get; set; }
}
