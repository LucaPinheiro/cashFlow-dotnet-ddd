namespace CashFlow.Domain.Repositories;

public interface IUserReadOnlyRepositories
{
    Task<bool> ExistActiveUserWithEmail(string email);
}