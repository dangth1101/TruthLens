using TruthLens.Domain.Entities;

namespace TruthLens.Application.Modules.MediaModule.Interfaces;

public interface IFileSimilarityRepository
{
    Task AddAsync(FileSimilarity fileSimilarity);
    Task<FileSimilarity?> GetByKeysAsync(Guid originalFileId, Guid duplicateFileId);
    Task DeleteAsync(Guid originalFileId, Guid duplicateFileId);
}
