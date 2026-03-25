using TruthLens.Application.Modules.MediaModule.Interfaces;

namespace TruthLens.Infrastructure.Modules.MediaModule.FileStorage;

public class AzureBlobStorageService : IFileStorageService
{
    public Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        // Implement Azure Blob Storage upload logic here
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(string fileUrl)
    {
        // Implement Azure Blob Storage deletion logic here
        throw new NotImplementedException();
    }
}