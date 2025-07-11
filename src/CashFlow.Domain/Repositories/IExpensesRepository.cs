using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories;

public interface IExpensesRepository
{
    public void Add(Expense expense);
}