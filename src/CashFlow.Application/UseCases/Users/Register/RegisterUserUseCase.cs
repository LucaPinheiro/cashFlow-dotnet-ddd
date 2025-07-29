using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Security;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users;

public class RegisterUserUseCase : IRegisterUserUseCase
{

    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;

    public RegisterUserUseCase(IMapper mapper, IPasswordEncripter passwordEncripter)
    {
        _mapper = mapper;
        passwordEncripter = passwordEncripter;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);
        user.password = _passwordEncripter.Encrypt(request.Password);

        return new ResponseRegisteredUserJson
        {
            Name = user.name
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors
                .Select(f => f.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

}