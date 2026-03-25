using Microsoft.EntityFrameworkCore;
using TruthLens.Domain.Entities;

namespace TruthLens.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<MediaFile> Files { get; set; }
    public DbSet<UploadEvent> UploadEvents { get; set; }
    public DbSet<FileSimilarity> FileSimilarities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
