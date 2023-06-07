using Application.Abstractions;
using Domain.UserTransaction;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserTransactionRepository : IUserTransactionRepository
{
    private readonly NauciProgramiranjeDbContext _context;

    public UserTransactionRepository(NauciProgramiranjeDbContext context)
    {
        _context = context;
    }

    public async Task<UserTransaction> AddUserTransaction(UserTransaction toCreate)
    {
        _context.UserTransaction.Add(toCreate);
        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task<ICollection<UserTransaction>> GetAllUserTransactions(string userId)
    {
        return await _context.UserTransaction.Where(t => t.UserId == userId).OrderBy(t => t.AddedDate).ToListAsync();
    }

    public async Task<UserTransaction> GetLastUserTransaction(string userId)
    {
        var latestDate = _context.UserTransaction.Max(t => t.AddedDate);
        return await _context.UserTransaction.FirstOrDefaultAsync(t => t.AddedDate == latestDate);
    }

    public async Task<UserTransaction> GetUserTransactionById(UserTransactionId chapterId)
    {
        return await _context.UserTransaction.FirstOrDefaultAsync(t => t.Id == chapterId);
    }
}
