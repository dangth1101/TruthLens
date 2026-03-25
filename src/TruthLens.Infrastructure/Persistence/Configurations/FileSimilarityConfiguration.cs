using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruthLens.Domain.Entities;

namespace TruthLens.Infrastructure.Persistence.Configurations;

public class FileSimilarityConfiguration : IEntityTypeConfiguration<FileSimilarity>
{
    public void Configure(EntityTypeBuilder<FileSimilarity> builder)
    {
        builder.ToTable("FileSimilarities");

        builder.HasKey(s => new { s.OriginalFileId, s.DuplicateFileId });

        builder.Property(s => s.OriginalFileId).IsRequired();
        builder.Property(s => s.DuplicateFileId).IsRequired();
        builder.Property(s => s.SimilarityScore);

        builder.HasOne<MediaFile>()
            .WithMany()
            .HasForeignKey(s => s.OriginalFileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<MediaFile>()
            .WithMany()
            .HasForeignKey(s => s.DuplicateFileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
