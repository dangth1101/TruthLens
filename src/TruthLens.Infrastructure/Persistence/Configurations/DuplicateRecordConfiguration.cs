using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruthLens.Domain.Entities;

namespace TruthLens.Infrastructure.Persistence.Configurations;

public class DuplicateRecordConfiguration : IEntityTypeConfiguration<DuplicateRecord>
{
    public void Configure(EntityTypeBuilder<DuplicateRecord> builder)
    {
        builder.ToTable("DuplicateRecords");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.OriginalUploadId).IsRequired();
        builder.Property(d => d.DuplicateUploadId).IsRequired();
        builder.Property(d => d.DetectedAt).IsRequired();

        builder.HasOne<MediaUpload>()
            .WithMany()
            .HasForeignKey(d => d.OriginalUploadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<MediaUpload>()
            .WithOne()
            .HasForeignKey<DuplicateRecord>(d => d.DuplicateUploadId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}