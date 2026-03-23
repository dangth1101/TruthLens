using TruthLens.Domain.ValueObjects;

namespace TruthLens.Domain.Entities;

public class MediaUpload
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Filename { get; set; } = string.Empty;
    public string StoragePath { get; set; } = string.Empty;
    public string FileHash { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string MimeType { get; set; } = string.Empty;
    public AiDetectionResult IsAiGenerated { get; set; }
    public float AiConfidenceScore { get; set; }
    public UploadStatus Status { get; set; }
    public DateTime UploadedAt { get; set; }
}