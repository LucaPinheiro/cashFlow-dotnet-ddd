using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
  public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
  {

    Validate(request);

    return new ResponseRegisteredExpenseJson
    {
      Title = request.Title,
    };
  }

  private void Validate(RequestRegisterExpenseJson request)
  {
    var validator = new RegisterExpenseValidator();
    var validationResult = validator.Validate(request);

    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(f => f.ErrorMessage).ToList();
      throw new ArgumentException(string.Join("; ", errorMessages));
    }
  }
}
