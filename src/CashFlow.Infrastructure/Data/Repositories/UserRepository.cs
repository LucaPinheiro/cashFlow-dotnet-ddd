using CashFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Data.Repositories;

public class UserRepository : IUserReadOnlyRepositories
{
    private readonly CashFlowDbContext _dbContext;

    public UserRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users
            .AnyAsync(u => u.email == email);
    }
}