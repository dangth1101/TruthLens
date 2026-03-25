using TruthLens.Domain.Entities;

namespace TruthLens.Domain.Tests.Entities;

public class UserTests
{
    [Fact]
    public void GivenValidArgs_WhenCreateCalled_ThenUserHasCorrectValues()
    {
        var beforeCreatedAt = DateTime.UtcNow;
        var user = User.Create("test_account", "secret123");
        var afterCreatedAt = DateTime.UtcNow;

        Assert.Equal("test_account", user.Username);
        Assert.Equal("secret123", user.Password);
        Assert.NotEqual(Guid.Empty, user.Id);
        Assert.InRange(user.CreatedAt, beforeCreatedAt, afterCreatedAt);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenBlankUsername_WhenCreateCalled_ThenThrowsArgumentException(string? username)
    {
        Assert.ThrowsAny<ArgumentException>(() => User.Create(username!, "secret123"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenBlankPassword_WhenCreateCalled_ThenThrowsArgumentException(string? password)
    {
        Assert.ThrowsAny<ArgumentException>(() => User.Create("test_account", password!));
    }
}
