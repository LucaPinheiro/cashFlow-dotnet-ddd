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

  public const string NAME_EMPTY = "Name cannot be empty.";
  public const string NAME_TOO_LONG = "Name cannot exceed 100 characters.";
  public const string EMAIL_EMPTY = "Email cannot be empty.";
  public const string EMAIL_INVALID = "Email is not valid.";
  public const string EMAIL_TOO_LONG = "Email is too long.";
  public const string INVALID_PASSWORD = "Password is invalid. It must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.";

}
