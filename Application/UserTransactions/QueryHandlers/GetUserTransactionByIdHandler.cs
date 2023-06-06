using Application.Abstractions;
using Application.UserTransactions.Queries;
using Domain.UserTransaction;
using MediatR;

namespace Application.UserTransactions.QueryHandlers;

public class GetUserTransactionByIdHandler : IRequestHandler<GetUserTransactionById, UserTransaction>
{
    private readonly IUserTransactionRepository _userTransactionRepository;

    public GetUserTransactionByIdHandler(IUserTransactionRepository userTransactionRepository)
    {
        _userTransactionRepository = userTransactionRepository;
    }

    public async Task<UserTransaction> Handle(GetUserTransactionById request, CancellationToken cancellationToken)
    {
        return await _userTransactionRepository.GetUserTransactionById(request.UserTransactionId);
    }
}