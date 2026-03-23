using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruthLens.Domain.Entities;

namespace TruthLens.Infrastructure.Persistence.Configurations;

public class MediaUploadConfiguration : IEntityTypeConfiguration<MediaUpload>
{
    public void Configure(EntityTypeBuilder<MediaUpload> builder)
    {
        builder.ToTable("MediaUploads");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Filename).IsRequired().HasMaxLength(260);
        builder.Property(d => d.StoragePath).IsRequired().HasMaxLength(1024);
        builder.Property(d => d.FileHash).IsRequired().HasMaxLength(64);
        builder.Property(d => d.FileSize).IsRequired();
        builder.Property(d => d.MimeType).IsRequired().HasMaxLength(100);
        builder.Property(d => d.AiConfidenceScore).IsRequired();
        builder.Property(d => d.UploadedAt).IsRequired();

        builder.Property(d => d.IsAiGenerated)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(d => d.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}