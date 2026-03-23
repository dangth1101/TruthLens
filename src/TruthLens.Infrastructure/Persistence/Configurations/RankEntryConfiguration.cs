using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruthLens.Domain.Entities;

namespace TruthLens.Infrastructure.Persistence.Configurations;

public class RankEntryConfiguration : IEntityTypeConfiguration<RankEntry>
{
    public void Configure(EntityTypeBuilder<RankEntry> builder)
    {
        builder.ToTable("RankEntries");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.TotalUploads).IsRequired();
        builder.Property(d => d.AiGeneratedCount).IsRequired();
        builder.Property(d => d.Score).IsRequired();
        builder.Property(d => d.LastUpdatedAt).IsRequired();

        builder.HasOne<MediaUpload>()
            .WithMany()
            .HasForeignKey(d => d.MediaUploadId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}