namespace TruthLens.Domain.Entities;

public class MediaFile
{
    public Guid Id { get; private set; } = Guid.Empty;
    public string FileName { get; private set; } = string.Empty;
    public string FileType { get; private set; } = string.Empty;
    public long FileSize { get; private set; }
    public string FilePath { get; private set; } = string.Empty;
    public string FileHash { get; private set; } = string.Empty;
    public string Status { get; private set; } = string.Empty;
    public float AiConfidenceScore { get; private set; }

    private MediaFile() { }

    public static MediaFile Create(string fileName, string fileType, long fileSize, string filePath, string fileHash)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
        ArgumentException.ThrowIfNullOrWhiteSpace(fileType);
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
        ArgumentException.ThrowIfNullOrWhiteSpace(fileHash);

        return new MediaFile
        {
            Id = Guid.NewGuid(),
            FileName = fileName,
            FileType = fileType,
            FileSize = fileSize,
            FilePath = filePath,
            FileHash = fileHash,
            Status = "Pending",
            AiConfidenceScore = 0f,
        };
    }
}
