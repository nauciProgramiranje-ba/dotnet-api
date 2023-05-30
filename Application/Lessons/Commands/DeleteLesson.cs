using Domain.Lesson;
using MediatR;

namespace Application.Lessons.Commands;

public class DeleteLesson : IRequest
{
    public LessonId LessonId { get; set; }
}
