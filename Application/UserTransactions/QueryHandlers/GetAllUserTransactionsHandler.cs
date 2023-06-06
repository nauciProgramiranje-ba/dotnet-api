using Application.Abstractions;
using Application.UserTransactions.Queries;
using Domain.UserTransaction;
using MediatR;

namespace Application.UserTransactions.QueryHandlers;

public class GetAllUserTransactionsHandler : IRequestHandler<GetAllUserTransactions, ICollection<UserTransaction>>
{
    private readonly IUserTransactionRepository _userTransactionRepository;

    public GetAllUserTransactionsHandler(IUserTransactionRepository userTransactionRepository)
    {
        _userTransactionRepository = userTransactionRepository;
    }

    public async Task<ICollection<UserTransaction>> Handle(GetAllUserTransactions request, CancellationToken cancellationToken)
    {
        return await _userTransactionRepository.GetAllUserTransactions();
    }
}
