using TruthLens.Domain.Entities;

namespace TruthLens.Domain.Tests.Entities;

public class MediaFileTests
{
    [Fact]
    public void GivenValidArgs_WhenCreateCalled_ThenMediaFileHasCorrectValues()
    {
        var fileName = "test_image.png";
        var fileType = "image/png";
        var fileSize = 1024L;
        var filePath = "/uploads/test_image.png";
        var fileHash = "abc123def456";

        var mediaFile = MediaFile.Create(fileName, fileType, fileSize, filePath, fileHash);

        Assert.Equal(fileName, mediaFile.FileName);
        Assert.Equal(fileType, mediaFile.FileType);
        Assert.Equal(fileSize, mediaFile.FileSize);
        Assert.Equal(filePath, mediaFile.FilePath);
        Assert.Equal(fileHash, mediaFile.FileHash);
        Assert.Equal("Pending", mediaFile.Status);
        Assert.Equal(0f, mediaFile.AiConfidenceScore);
        Assert.NotEqual(Guid.Empty, mediaFile.Id);
    }

    [Theory]
    [InlineData(null, "image/png", "/path", "hash")]
    [InlineData("", "image/png", "/path", "hash")]
    [InlineData("file.png", null, "/path", "hash")]
    [InlineData("file.png", "", "/path", "hash")]
    [InlineData("file.png", "image/png", null, "hash")]
    [InlineData("file.png", "image/png", "", "hash")]
    [InlineData("file.png", "image/png", "/path", null)]
    [InlineData("file.png", "image/png", "/path", "")]
    public void GivenBlankRequiredArg_WhenCreateCalled_ThenThrowsArgumentException(
        string? fileName, string? fileType, string? filePath, string? fileHash)
    {
        Assert.ThrowsAny<ArgumentException>(() =>
            MediaFile.Create(fileName!, fileType!, 1024L, filePath!, fileHash!));
    }
}
