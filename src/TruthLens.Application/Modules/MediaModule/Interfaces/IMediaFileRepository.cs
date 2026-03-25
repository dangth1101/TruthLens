using TruthLens.Domain.Entities;

namespace TruthLens.Application.Modules.MediaModule.Interfaces;

public interface IMediaFileRepository
{
    Task AddAsync(MediaFile mediaFile);
    Task<MediaFile?> GetByIdAsync(Guid id);
    Task<MediaFile?> GetByHashAsync(string fileHash);
    Task UpdateAsync(MediaFile mediaFile);
    Task DeleteAsync(Guid id);
}
