using CashFlow.Application.UseCases.Login;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using FluentAssertions;

namespace UseCases.Test.Users.Login;

public class DoLoginUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var user = UserBuilder.Build();

        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.email;

        var usecase = CreateUseCase(user, request.Password);

        var result = await usecase.Execute(request);

        result.Should().NotBeNull();
        result.Name.Should().Be(user.name);
        result.Token.Should().NotBeNullOrEmpty();
    }


    private DoLoginUseCase CreateUseCase(CashFlow.Domain.Entities.User user, string? password = null)
    {
        var passwordEncrypter = new PasswordEncripterBuilder().Verify(password).Build();
        var tokenGenerator = JwtTokenGeneratorBuilder.Build();
        var readRepository = new UserReadOnlyRepositorybuilder().GetUserByEmail(user).Build();


        return new DoLoginUseCase(readRepository, passwordEncrypter, tokenGenerator);
    }
}