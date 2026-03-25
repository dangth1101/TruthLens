namespace TruthLens.Domain.Entities;

public class FileSimilarity
{
    public Guid OriginalFileId { get; private set; }
    public Guid DuplicateFileId { get; private set; }
    public float? SimilarityScore { get; private set; }

    private FileSimilarity() { }

    public static FileSimilarity Create(Guid originalFileId, Guid duplicateFileId, float? similarityScore = null)
    {
        if (originalFileId == Guid.Empty) throw new ArgumentException("OriginalFileId must not be empty.", nameof(originalFileId));
        if (duplicateFileId == Guid.Empty) throw new ArgumentException("DuplicateFileId must not be empty.", nameof(duplicateFileId));

        return new FileSimilarity
        {
            OriginalFileId = originalFileId,
            DuplicateFileId = duplicateFileId,
            SimilarityScore = similarityScore,
        };
    }
}
