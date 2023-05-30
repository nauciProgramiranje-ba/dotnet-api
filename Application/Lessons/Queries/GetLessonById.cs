using Domain.Lesson;
using MediatR;

namespace Application.Lessons.Queries;

public class GetLessonById : IRequest<Lesson>
{
    public LessonId LessonId { get; set; }
}
