namespace CashFlow.Domain.Entities;

public class User
{
    public long id { get; set; }
    public string name { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public Guid UserIdentifier { get; set; } = Guid.NewGuid();
    public string Role { get; set; } = "User"; 
}