using Application.Abstractions;
using Application.UserTransactions.Queries;
using Domain.UserTransaction;
using MediatR;

namespace Application.UserTransactions.QueryHandlers;

public class GetLastTransactionHandler : IRequestHandler<GetLastTransaction, UserTransaction>
{
    private readonly IUserTransactionRepository _userTransactionRepository;

    public GetLastTransactionHandler(IUserTransactionRepository userTransactionRepository)
    {
        _userTransactionRepository = userTransactionRepository;
    }

    public async Task<UserTransaction> Handle(GetLastTransaction request, CancellationToken cancellationToken)
    {
        return await _userTransactionRepository.GetLastUserTransaction(request.UserId);
    }
}
