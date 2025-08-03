namespace CashFlow.Domain.Repositories;

public interface IUserReadOnlyRepositories
{
    Task<bool> ExistActiveUserWithEmail(string email);
    Task<Entities.User?> GetUserByEmail(string email);
}