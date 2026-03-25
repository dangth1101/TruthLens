using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruthLens.Domain.Entities;

namespace TruthLens.Infrastructure.Persistence.Configurations;

public class MediaFileConfiguration : IEntityTypeConfiguration<MediaFile>
{
    public void Configure(EntityTypeBuilder<MediaFile> builder)
    {
        builder.ToTable("Files");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.FileName)
            .IsRequired()
            .HasMaxLength(260);

        builder.Property(f => f.FileType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.FileSize).IsRequired();

        builder.Property(f => f.FilePath)
            .IsRequired()
            .HasMaxLength(1024);

        builder.Property(f => f.FileHash)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasIndex(f => f.FileHash).IsUnique();

        builder.Property(f => f.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(f => f.AiConfidenceScore).IsRequired();
    }
}
