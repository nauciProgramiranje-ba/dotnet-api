using Domain.UserTransaction;

namespace Application.Abstractions;

public interface IUserTransactionRepository
{
    Task<ICollection<UserTransaction>> GetAllUserTransactions();

    Task<UserTransaction> GetUserTransactionById(UserTransactionId chapterId);

    Task<UserTransaction> AddUserTransaction(UserTransaction toCreate);
}
