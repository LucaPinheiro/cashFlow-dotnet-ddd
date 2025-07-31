namespace CashFlow.Infrastructure.Security;

using BCrypt.Net;

public class BCrypter : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BCrypt.HashPassword(password);
        return passwordHash;
    }
}
