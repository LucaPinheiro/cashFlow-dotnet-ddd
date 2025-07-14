namespace CashFlow.Communication.Responses;

public class ResponseShortExpenseJson
{
    public long Id { get; set; }
    public string Tilte { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}