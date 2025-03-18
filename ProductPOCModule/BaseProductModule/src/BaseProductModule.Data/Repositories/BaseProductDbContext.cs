using BaseProductModule.Data.Model;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;

namespace BaseProductModule.Data.Repositories;

/// <summary>
/// Represents the database context for the Base Product module.
/// </summary>
public class BaseProductDbContext : DbContextWithTriggers
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseProductDbContext"/> class.
    /// </summary>
    /// <param name="options">The options for configuring the database context.</param>
    public BaseProductDbContext(DbContextOptions<BaseProductDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseProductDbContext"/> class.
    /// This constructor is used for inherited contexts.
    /// </summary>
    /// <param name="options">The database context options.</param>
    protected BaseProductDbContext(DbContextOptions options)
    : base(options)
    {
    }

    /// <summary>
    /// Configures the entity mappings for the database.
    /// </summary>
    /// <param name="modelBuilder">The model builder used for configuring entities.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>()
           .ToTable("Produts"); // Typo: Should be "Products" instead of "Produts"

        modelBuilder.Entity<ProductEntity>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18,4)");
    }
}
