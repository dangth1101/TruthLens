using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruthLens.Domain.Entities;

namespace TruthLens.Infrastructure.Persistence.Configurations;

public class UploadEventConfiguration : IEntityTypeConfiguration<UploadEvent>
{
    public void Configure(EntityTypeBuilder<UploadEvent> builder)
    {
        builder.ToTable("UploadEvents");

        builder.HasKey(e => new { e.UserId, e.FileId });

        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.FileId).IsRequired();
        builder.Property(e => e.UploadedAt).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<MediaFile>()
            .WithMany()
            .HasForeignKey(e => e.FileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
