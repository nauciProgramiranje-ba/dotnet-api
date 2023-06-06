using Application.Abstractions;
using Application.UserTransactions.Commands;
using Domain.UserTransaction;
using MediatR;

namespace Application.UserTransactions.CommandHandlers;

internal class CreateUserTransactionHandler : IRequestHandler<CreateUserTransaction, UserTransaction>
{
    private readonly IUserTransactionRepository _userTransactionRepository;

    public CreateUserTransactionHandler(IUserTransactionRepository userTransactionRepository)
    {
        _userTransactionRepository = userTransactionRepository;
    }

    public async Task<UserTransaction> Handle(CreateUserTransaction request, CancellationToken cancellationToken)
    {
        var transaction = new UserTransaction
        {
            Id = new UserTransactionId(Guid.NewGuid()),
            UserId = request.UserId,
            Amount = request.Amount,
            AddedDate = DateTime.Now,
            LastModified = DateTime.Now,
        };

        return await _userTransactionRepository.AddUserTransaction(transaction);
    }
}
