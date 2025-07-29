using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ErrorMessages.NAME_EMPTY)
            .MaximumLength(100).WithMessage(ErrorMessages.NAME_TOO_LONG);

        RuleFor(user => user.Email).NotEmpty().WithMessage(ErrorMessages.EMAIL_EMPTY)
            .EmailAddress().WithMessage(ErrorMessages.EMAIL_INVALID)
            .MaximumLength(100).WithMessage(ErrorMessages.EMAIL_TOO_LONG);

        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
    }
}