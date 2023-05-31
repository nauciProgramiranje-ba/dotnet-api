using Domain.Chapter;
using Domain.Lesson;
using MediatR;

namespace Application.Lessons.Queries;

public class GetLessonsByChapterId : IRequest<ICollection<Lesson>>
{
    public ChapterId ChapterId { get; set; }
}
