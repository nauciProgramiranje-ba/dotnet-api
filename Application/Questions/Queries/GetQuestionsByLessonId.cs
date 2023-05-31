using Domain.Lesson;
using Domain.Question;
using MediatR;

namespace Application.Questions.Queries;

public class GetQuestionsByLessonId : IRequest<ICollection<Question>>
{
    public LessonId LessonId { get; set; }
}
