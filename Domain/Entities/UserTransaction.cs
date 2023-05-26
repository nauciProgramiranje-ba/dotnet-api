using Domain.Primitives;
using System.Data.SqlTypes;

namespace Domain.Entities;

public sealed class UserTransaction : Entity
{
    public UserTransaction(Guid id, User user, DateTime paidDate, SqlMoney amount) 
        : base(id)
    {
        User = user;
        PaidDate = paidDate;
        Amount = amount;
    }

    public User User { get; set; }

    public DateTime PaidDate { get; set;}

    public SqlMoney Amount { get; set;}
}
