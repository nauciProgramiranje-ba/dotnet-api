using Domain.Lesson;
using Domain.Primitives;

namespace Domain.Question;

public sealed class Question : Entity
{
    public QuestionId Id { get; set; }

    public LessonId LessonId { get; set; }

    public string Prompt { get; set; } = string.Empty;

    public string Answer { get; set; } = string.Empty;

    public bool IsCodeQuestion { get; set; }

    public int QuestionNumber { get; set; }

    public string PossibleAnswers { get; set; }
}
