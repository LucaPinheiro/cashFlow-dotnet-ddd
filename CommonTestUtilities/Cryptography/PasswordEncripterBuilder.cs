using CashFlow.Infrastructure.Security;
using Moq;

namespace CommonTestUtilities.Cryptography;

public class PasswordEncripterBuilder
{
    private readonly Mock<IPasswordEncripter> _mock;

    public PasswordEncripterBuilder()
    {
        _mock = new Mock<IPasswordEncripter>();

        _mock.Setup(p => p.Encrypt(It.IsAny<string>()))
            .Returns("!%dlfJk545");
    }

    public PasswordEncripterBuilder Verify(string? password)
    {

        if (string.IsNullOrWhiteSpace(password) == false)
        {
            _mock.Setup(p => p.Verify(password, It.IsAny<string>()))
                .Returns(true);
        }

        return this;
    }

    public IPasswordEncripter Build() => _mock.Object;
}