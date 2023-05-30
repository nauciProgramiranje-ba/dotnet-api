using Domain.Chapter;
using Domain.Lesson;
using MediatR;

namespace Application.Lessons.Commands;

public class CreateLesson : IRequest<Lesson>
{
    public ChapterId ChapterId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Uri VideoUrl { get; set; }

    public int LessonNumber { get; set; }
}
