using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Repositories;
using CashFlow.Infrastructure.Security;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Infrastructure.Security;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Users;

public class RegisterUserUseCase : IRegisterUserUseCase
{

    private readonly IMapper _mapper;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IUserReadOnlyRepositories _userRepo;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository; 
    private readonly IUnitOfWork _unitOfWork;

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
        user.UserIdentifier = Guid.NewGuid();
        user.Role = Roles.TEAM_MEMBER;

        await _userWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Name = user.name
        };
    }

    private async void Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);
        var userExists = await _userRepo.ExistActiveUserWithEmail(request.Email);
        if (userExists)
        {
            result.Errors.Add(new ValidationFailure(
                nameof(request.Email),
                "Já existe um usuário ativo com este email"
            ));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors
                .Select(f => f.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

}