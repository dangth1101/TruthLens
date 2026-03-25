using TruthLens.Application.Modules.MediaModule.Interfaces;

namespace TruthLens.Infrastructure.Modules.MediaModule.FileStorage;

public class S3FileStorageService : IFileStorageService
{
    public Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        // Implement S3 file storage logic here
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(string fileUrl)
    {
        // Implement S3 file deletion logic here
        throw new NotImplementedException();
    }
}