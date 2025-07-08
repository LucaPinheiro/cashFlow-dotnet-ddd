using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
  [Fact]
  public void Test_ValidExpense_ShouldPassValidation()
  {
    // Arrange
    var validator = new RegisterExpenseValidator();

    var request = RequestRegisterExpenseJsonBuilder.Build();

    // Act
    var result = validator.Validate(request);

    // Assert
    Assert.True(result.IsValid);
  }
}
