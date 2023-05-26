using Domain.User;

namespace Domain.UserTransaction;

public class UserTransaction 
{
    public UserTransactionId Id { get; set; }

    public UserId UserId { get; set; }

    public DateTime PaidDate { get; set; }

    public decimal Amount { get; set; }
}
