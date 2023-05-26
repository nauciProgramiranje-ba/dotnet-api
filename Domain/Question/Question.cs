using Domain.Lesson;

namespace Domain.Question;

public class Question
{
    public QuestionId Id { get; set; }

    public LessonId LessonId { get; set; }

    public string Prompt { get; set; } = string.Empty;

    public string Answer { get; set; } = string.Empty;

    public bool IsCodeQuestion { get; set; }
}
