using Microsoft.EntityFrameworkCore;
using TruthLens.Application.Modules.MediaModule.Interfaces;
using TruthLens.Domain.Entities;
using TruthLens.Infrastructure.Persistence;

namespace TruthLens.Infrastructure.Modules.MediaModule.Repositories;

public class MediaFileRepository(AppDbContext dbContext) : IMediaFileRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task AddAsync(MediaFile mediaFile)
    {
        await _dbContext.Files.AddAsync(mediaFile);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _dbContext.Files.Where(f => f.Id == id).ExecuteDeleteAsync();
    }

    public async Task<MediaFile?> GetByHashAsync(string fileHash)
    {
        return await _dbContext.Files.FirstOrDefaultAsync(f => f.FileHash == fileHash);
    }

    public async Task<MediaFile?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Files.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task UpdateAsync(MediaFile mediaFile)
    {
        _dbContext.Files.Update(mediaFile);
        await _dbContext.SaveChangesAsync();
    }
}
