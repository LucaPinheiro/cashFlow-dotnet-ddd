using Bogus;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Cryptography;

namespace CommonTestUtilities.Entities;

public class UserBuilder
{
    public static User Build()
    {
        var passwordEncripter = new PasswordEncripterBuilder().Build();

        var user = new Faker<User>()
            .RuleFor(u => u.id, _ => 1)
            .RuleFor(u => u.name, faker => faker.Person.FirstName)
            .RuleFor(u => u.email, (faker, user) => faker.Internet.Email(user.name))
            .RuleFor(u => u.password, (_, user) => passwordEncripter.Encrypt(user.password))
            .RuleFor(u => u.UserIdentifier, _ => Guid.NewGuid());

        return user;
    }
}