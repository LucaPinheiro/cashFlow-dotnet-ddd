using System.Text.RegularExpressions;
using CashFlow.Communication.Enums;
using FluentValidation;
using FluentValidation.Validators;

namespace CashFlow.Application.UseCases.Users;

public class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";

    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return "{ErrorMessage}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 100)
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (!Regex.IsMatch(password, @"[A-Z]")) // precisa de ao menos uma maiúscula
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (!Regex.IsMatch(password, @"[a-z]")) // precisa de ao menos uma minúscula
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (!Regex.IsMatch(password, @"\d")) // precisa de ao menos um número
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ErrorMessages.INVALID_PASSWORD);
            return false;
        }

        return true;
    }
}