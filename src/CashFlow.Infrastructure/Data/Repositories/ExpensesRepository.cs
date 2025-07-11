using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Data.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly CashFlowDbContext _dbContext;

        public ExpensesRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Expense expense)
        {
            _dbContext.Expenses.Add(expense);
        }

        public async Task AddAsync(Expense expense)
        {
            await _dbContext.Expenses.AddAsync(expense);
            await _dbContext.SaveChangesAsync();
        }
    }
}