using TruthLens.Domain.Entities;

namespace TruthLens.Domain.Tests.Entities;

public class UserTests
{
    [Fact]
    public void GivenValidArgs_WhenCreateCalled_ThenUserHasCorrectValues()
    {
        var beforeCreatedAt = DateTime.UtcNow;
        var user = User.Create("test_account", "account@test.com");
        var afterCreatedAt = DateTime.UtcNow;

        Assert.Equal("test_account", user.Username);
        Assert.Equal("account@test.com", user.Email);
        Assert.Equal(0, user.UploadCount);
        Assert.NotEqual(Guid.Empty, user.Id);
        Assert.InRange(user.CreatedAt, beforeCreatedAt, afterCreatedAt);
        Assert.InRange(user.ModifiedAt, beforeCreatedAt, afterCreatedAt);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenBlankUsername_WhenCreateCalled_ThenThrowsArgumentException(string? username)
    {
        Assert.ThrowsAny<ArgumentException>(() => User.Create(username!, "account@test.com"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenBlankEmail_WhenCreateCalled_ThenThrowsArgumentException(string? email)
    {
        Assert.ThrowsAny<ArgumentException>(() => User.Create("test_account", email!));
    }

    [Fact]
    public void GivenNewUser_WhenIncrementUploadCountCalled_ThenUploadCountIsOne()
    {
        var user = User.Create("test_account", "account@test.com");

        var beforeModifiedAt = DateTime.UtcNow;
        user.IncrementUploadCount();
        var afterModifiedAt = DateTime.UtcNow;

        Assert.Equal(1, user.UploadCount);
        Assert.InRange(user.ModifiedAt, beforeModifiedAt, afterModifiedAt);
    }


    [Fact]
    public void GivenNewUser_WhenIncrementUploadCountCalledMultipleTimes_ThenUploadCountAccumulates()
    {
        var user = User.Create("test_account", "account@test.com");

        user.IncrementUploadCount();
        user.IncrementUploadCount();
        var beforeModifiedAt = DateTime.UtcNow;
        user.IncrementUploadCount();
        var afterModifiedAt = DateTime.UtcNow;

        Assert.Equal(3, user.UploadCount);
        Assert.InRange(user.ModifiedAt, beforeModifiedAt, afterModifiedAt);
    }

    [Theory]
    [InlineData("account@test.com")]
    [InlineData("user.name+tag@sub.domain.com")]
    public void GivenValidEmail_WhenIsValidEmailCalled_ThenReturnTrue(string email)
    {
        Assert.True(User.IsValidEmail(email));
    }

    [Theory]
    [InlineData("account_test.com")]
    [InlineData("@nodomain")]
    [InlineData("two@@at.com")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void GivenInvalidEmail_WhenIsValidEmailCalled_ThenReturnFalse(string? email)
    {
        Assert.False(User.IsValidEmail(email!));
    }
}