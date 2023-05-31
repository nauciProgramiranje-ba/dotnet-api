using Domain.Primitives;
using Domain.Question;
using Domain.User;

namespace Domain.UserProgress;

public sealed class UserProgress : Entity
{
    public UserProgressId Id { get; set; }

    public UserId UserId { get; set; }

    public QuestionId QuestionId { get; set; }

    public string UserAnswer { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}
