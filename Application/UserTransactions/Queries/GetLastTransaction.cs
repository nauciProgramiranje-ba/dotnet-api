using Domain.UserTransaction;
using MediatR;

namespace Application.UserTransactions.Queries;

public class GetLastTransaction : IRequest<UserTransaction>
{
    public string UserId { get; set; }
}
