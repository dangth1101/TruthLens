using System.Net.Mail;

namespace TruthLens.Domain.Entities;

public class User
{
    public Guid Id { get; private set; } = Guid.Empty;
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime ModifiedAt { get; private set; }
    public int UploadCount { get; private set; }

    private User() { }

    public static User Create(string username, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(username);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        if (!IsValidEmail(email)) throw new ArgumentException("Invalid email");

        return new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Email = email,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
            UploadCount = 0,
        };
    }

    public void IncrementUploadCount()
    {
        UploadCount++;
        ModifiedAt = DateTime.UtcNow;
    }

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        return MailAddress.TryCreate(email, out var emailAddress)
            && emailAddress.Address == email;
    }
}