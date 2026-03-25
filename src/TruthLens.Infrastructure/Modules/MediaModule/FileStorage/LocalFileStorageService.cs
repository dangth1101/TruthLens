using TruthLens.Application.Modules.MediaModule.Interfaces;

namespace TruthLens.Infrastructure.Modules.MediaModule.FileStorage;

public class LocalFileStorageService : IFileStorageService
{
    private readonly string _storageRoot = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        Directory.CreateDirectory(_storageRoot);

        string uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        string filePath = Path.Combine(_storageRoot, uniqueFileName);

        using var fileOutput = File.Create(filePath);
        await fileStream.CopyToAsync(fileOutput);

        return filePath;
    }

    public Task DeleteFileAsync(string fileUrl)
    {
        if (File.Exists(fileUrl))
            File.Delete(fileUrl);

        return Task.CompletedTask;
    }
}
