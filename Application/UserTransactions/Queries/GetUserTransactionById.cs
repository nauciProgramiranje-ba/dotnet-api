using Domain.UserTransaction;
using MediatR;

namespace Application.UserTransactions.Queries;

public class GetUserTransactionById : IRequest<UserTransaction>
{
    public UserTransactionId UserTransactionId { get; set; }
}
