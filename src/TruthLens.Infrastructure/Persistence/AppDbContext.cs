using Microsoft.EntityFrameworkCore;
using TruthLens.Domain.Entities;

namespace TruthLens.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<RankEntry> RankEntries { get; set; }
    public DbSet<MediaUpload> MediaUploads { get; set; }
    public DbSet<DuplicateRecord> DuplicateRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}