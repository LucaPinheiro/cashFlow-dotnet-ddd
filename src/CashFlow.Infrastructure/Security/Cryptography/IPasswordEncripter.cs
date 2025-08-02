namespace CashFlow.Infrastructure.Security;

public interface IPasswordEncripter
{
   string Encrypt(string password);
}