using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.SchemaDefinitions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure {
  public class CatalogContext : DbContext, IUnitOfWork {
    public const string DefaultSchema = "catalog";
    public DbSet<Item> Items { get; set; }
    public CatalogContext (DbContextOptions<CatalogContext> options) : base(options) { }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
      modelBuilder.ApplyConfiguration(new ItemEntitySchemaDefinition());
      modelBuilder.ApplyConfiguration(new GenreEntitySchemaConfiguration());
      modelBuilder.ApplyConfiguration(new ArtistEntitySchemaConfiguration());
      base.OnModelCreating(modelBuilder);
    }
    public async Task<bool> SaveEntitiesAsync (CancellationToken cancellationToken = default) {
      await SaveChangesAsync(cancellationToken);
      return true;
    }
  }
}