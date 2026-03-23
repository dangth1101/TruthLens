namespace TruthLens.Domain.Entities;

public class DuplicateRecord
{
    public Guid Id { get; set; }
    public Guid OriginalUploadId { get; set; }
    public Guid DuplicateUploadId { get; set; }
    public DateTime DetectedAt { get; set; }
}