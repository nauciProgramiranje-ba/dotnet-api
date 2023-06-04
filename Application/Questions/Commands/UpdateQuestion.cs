using Domain.Lesson;
using Domain.Question;
using MediatR;

namespace Application.Questions.Commands;

public class UpdateQuestion : IRequest<Question>
{
    public QuestionId QuestionId { get; set; }

    public LessonId LessonId { get; set; }

    public string Prompt { get; set; } = string.Empty;

    public string Answer { get; set; } = string.Empty;

    public bool IsCodeQuestion { get; set; }

    public int QuestionNumber { get; set; }

    public string PossibleAnswers { get; set; }
}
