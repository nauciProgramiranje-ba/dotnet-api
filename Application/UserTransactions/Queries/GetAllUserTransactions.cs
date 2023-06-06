using Domain.UserTransaction;
using MediatR;

namespace Application.UserTransactions.Queries;

public class GetAllUserTransactions : IRequest<ICollection<UserTransaction>>
{
}
