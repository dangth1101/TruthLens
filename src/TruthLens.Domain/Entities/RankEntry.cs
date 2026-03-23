namespace TruthLens.Domain.Entities;

public class RankEntry
{
    public Guid Id {get; set;}
    public Guid MediaUploadId {get; set;}
    public int TotalUploads {get; set;}
    public int AiGeneratedCount {get; set;}
    public float Score {get; set;}
    public DateTime LastUpdatedAt {get; set;}
}