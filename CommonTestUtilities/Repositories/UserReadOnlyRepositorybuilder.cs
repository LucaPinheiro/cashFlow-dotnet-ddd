using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;

public class UserReadOnlyRepositorybuilder
{
    private readonly Mock<IUserReadOnlyRepository> _repository;

    public UserReadOnlyRepositorybuilder()
    {
        _repository = new Mock<IUserReadOnlyRepository>();
    }

    public void ExistActiveUserWithEmail(string email)
    {
        _repository.Setup(userReadOnly => userReadOnly.ExistActiveUserWithEmail(email)).ReturnsAsync(true);

    }

    public UserReadOnlyRepositorybuilder GetUserByEmail(User user)
    {
        _repository.Setup(userRepository => userRepository.GetUserByEmail(user.email)).ReturnsAsync(user);

        return this;

    }

    public IUserReadOnlyRepository Build() => _repository.Object;
}