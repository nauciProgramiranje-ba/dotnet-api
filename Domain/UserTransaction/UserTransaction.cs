using Domain.Primitives;
using Domain.User;

namespace Domain.UserTransaction;

public sealed class UserTransaction : Entity
{
    public UserTransactionId Id { get; set; }

    public UserId UserId { get; set; }

    public DateTime PaidDate { get; set; }

    public decimal Amount { get; set; }
}
