using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories;

public interface IExpensesRepository
{
    Task Add(Expense expense);
}