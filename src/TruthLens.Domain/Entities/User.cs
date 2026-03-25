namespace TruthLens.Domain.Entities;

public class User
{
    public Guid Id { get; private set; } = Guid.Empty;
    public string Username { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    private User() { }

    public static User Create(string username, string password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(username);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        return new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Password = password,
            CreatedAt = DateTime.UtcNow,
        };
    }
}
