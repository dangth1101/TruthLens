using TruthLens.Application.Modules.MediaModule.Interfaces;
using TruthLens.Domain.Entities;

namespace TruthLens.Application.Modules.MediaModule.UseCases;

public class UploadMediaUseCase(IFileStorageService fileStorageService, IHashService hashService, IMediaFileRepository mediaFileRepository, IFileSimilarityRepository fileSimilarityRepository)
{
    private readonly IFileStorageService _fileStorageService = fileStorageService;
    private readonly IHashService _hashService = hashService;
    private readonly IMediaFileRepository _mediaFileRepository = mediaFileRepository;
    private readonly IFileSimilarityRepository _fileSimilarityRepository = fileSimilarityRepository;

    public async Task<string> ExecuteAsync(Guid userId, Stream fileStream, string fileName, string contentType)
    {
        if (userId == Guid.Empty) throw new ArgumentException("userId must not be empty.", nameof(userId));

        long fileSize = fileStream.Length;
        string fileHash = _hashService.ComputeHash(fileStream);
        fileStream.Position = 0;

        var existingFile = await _mediaFileRepository.GetByHashAsync(fileHash);
        bool isExactDuplicate = existingFile != null;

        string filePath;
        MediaFile mediaFile;

        if (isExactDuplicate)
        {
            mediaFile = existingFile!;
            filePath = mediaFile.FilePath;
        }
        else
        {
            filePath = await _fileStorageService.UploadFileAsync(fileStream, fileName, contentType);
            mediaFile = MediaFile.Create(fileName, contentType, fileSize, filePath, fileHash);
            await _mediaFileRepository.AddAsync(mediaFile);
        }

        // TODO: create and persist UploadEvent via IUploadEventRepository (Phase 2)

        if (isExactDuplicate)
        {
            var similarity = FileSimilarity.Create(existingFile!.Id, mediaFile.Id);
            await _fileSimilarityRepository.AddAsync(similarity);
        }

        return filePath;
    }
}
