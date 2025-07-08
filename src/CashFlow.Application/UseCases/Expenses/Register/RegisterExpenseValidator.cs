using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using FluentValidation;


namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
  public RegisterExpenseValidator()
  {
    RuleFor(expense => expense.Title).NotEmpty().WithMessage(ErrorMessages.TITLE_REQUIRED);
    RuleFor(expense => expense.Description).NotEmpty().WithMessage(ErrorMessages.DESCRIPTION_REQUIRED);
    RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ErrorMessages.AMOUNT_GREATER_THAN_ZERO);
    RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ErrorMessages.DATE_IN_FUTURE);
    RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ErrorMessages.PAYMENT_TYPE_INVALID);
  }
}