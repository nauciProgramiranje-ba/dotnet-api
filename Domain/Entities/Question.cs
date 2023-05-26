using Domain.Primitives;

namespace Domain.Entities;

public sealed class Question : Entity
{
    public Question(Guid id, Lesson lesson, string propmt, string answer, bool isCodeQuestion) 
        : base(id)
    {
        Lesson = lesson;
        Prompt = propmt;
        Answer = answer;
        IsCodeQuestion = isCodeQuestion;
    }

    public Lesson Lesson { get; set; }

    public string Prompt { get; set; }
    
    public string Answer { get; set; }
    
    public bool IsCodeQuestion { get; set; }
}
