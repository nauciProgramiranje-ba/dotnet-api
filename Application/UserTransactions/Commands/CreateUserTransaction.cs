using Domain.UserTransaction;
using MediatR;

namespace Application.UserTransactions.Commands;

public class CreateUserTransaction : IRequest<UserTransaction>
{
    public string UserId { get; set; }

    public decimal Amount { get; set; }
}
