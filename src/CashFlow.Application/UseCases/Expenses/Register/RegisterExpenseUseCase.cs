using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Infrastructure.Data;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
  private readonly IExpensesRepository _repository;

  public RegisterExpenseUseCase(IExpensesRepository repository)
  {
    _repository = repository;
  }

  public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
  {
    Validate(request);

    var entity = new Expense
    {
      Title = request.Title,
      Amount = request.Amount,
      Date = request.Date,
      Description = request.Description,
      PaymentType = (CashFlow.Domain.Enums.PaymentType)request.PaymentType,
    };

    _repository.Add(entity);

    return new ResponseRegisteredExpenseJson
    {
      Title = entity.Title,
    };
  }

  private void Validate(RequestRegisterExpenseJson request)
  {
    var validator = new RegisterExpenseValidator();
    var validationResult = validator.Validate(request);

    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(f => f.ErrorMessage).ToList();
      throw new ErrorOnValidationException(errorMessages);
    }
  }
}
