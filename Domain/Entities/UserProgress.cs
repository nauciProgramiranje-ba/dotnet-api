using Domain.Primitives;

namespace Domain.Entities;

public sealed class UserProgress : Entity
{
    public UserProgress(Guid id, User user, Question question, string userAnswer, bool isCompleted) 
        : base(id)
    {
        User = user;
        Question = question;
        UserAnswer = userAnswer;
        IsCompleted = isCompleted;
    }

    public User User { get; set; }

    public Question Question { get; set; }

    public string UserAnswer { get; set; }

    public bool IsCompleted { get; set; }
}
