using Domain.Primitives;

namespace Domain.UserTransaction;

public sealed class UserTransaction : Entity
{
    public UserTransactionId Id { get; set; }

    public string UserId { get; set; }

    public decimal Amount { get; set; }
}
