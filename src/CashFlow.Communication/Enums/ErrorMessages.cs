namespace CashFlow.Communication.Enums;

public static class ErrorMessages
{
  public const string UNKNOWN_ERROR = "An unknown error occurred.";
  public const string VALIDATION_ERROR = "Validation failed for one or more properties.";
  public const string TITLE_REQUIRED = "Title is required.";
  public const string DESCRIPTION_REQUIRED = "Description is required.";
  public const string AMOUNT_GREATER_THAN_ZERO = "Amount must be greater than zero.";
  public const string DATE_IN_FUTURE = "Date cannot be in the future.";
  public const string PAYMENT_TYPE_INVALID = "Payment type is invalid.";
  public const string EXPENSE_NOT_FOUND = "Expense not found.";

}
