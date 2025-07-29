namespace CashFlow.Infrastructure.Security;

using BC = BCrypt.Net.BCrypt;

public class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }
}