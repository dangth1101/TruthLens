namespace TruthLens.Domain.Entities;

public class UploadEvent
{
    public Guid UserId { get; private set; }
    public Guid FileId { get; private set; }
    public DateTime UploadedAt { get; private set; }

    private UploadEvent() { }

    public static UploadEvent Create(Guid userId, Guid fileId)
    {
        if (userId == Guid.Empty) throw new ArgumentException("UserId must not be empty.", nameof(userId));
        if (fileId == Guid.Empty) throw new ArgumentException("FileId must not be empty.", nameof(fileId));

        return new UploadEvent
        {
            UserId = userId,
            FileId = fileId,
            UploadedAt = DateTime.UtcNow,
        };
    }
}
