using Microsoft.EntityFrameworkCore;
using TruthLens.Application.Modules.MediaModule.Interfaces;
using TruthLens.Domain.Entities;
using TruthLens.Infrastructure.Persistence;

namespace TruthLens.Infrastructure.Modules.MediaModule.Repositories;

public class FileSimilarityRepository(AppDbContext dbContext) : IFileSimilarityRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task AddAsync(FileSimilarity fileSimilarity)
    {
        await _dbContext.FileSimilarities.AddAsync(fileSimilarity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<FileSimilarity?> GetByKeysAsync(Guid originalFileId, Guid duplicateFileId)
    {
        return await _dbContext.FileSimilarities
            .FirstOrDefaultAsync(s => s.OriginalFileId == originalFileId && s.DuplicateFileId == duplicateFileId);
    }

    public async Task DeleteAsync(Guid originalFileId, Guid duplicateFileId)
    {
        await _dbContext.FileSimilarities
            .Where(s => s.OriginalFileId == originalFileId && s.DuplicateFileId == duplicateFileId)
            .ExecuteDeleteAsync();
    }
}
