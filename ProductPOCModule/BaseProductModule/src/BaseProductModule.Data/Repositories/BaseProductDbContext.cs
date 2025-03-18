using BaseProductModule.Data.Model;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProductModule.Data.Repositories;

public class BaseProductDbContext : DbContextWithTriggers
{
    public BaseProductDbContext(DbContextOptions<BaseProductDbContext> options) : base(options)
    {
    }

    protected BaseProductDbContext(DbContextOptions options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>()
           .ToTable("Produts");

        modelBuilder.Entity<ProductEntity>()
            .Property(p => p.MetaData)
            .HasConversion(
                v => JsonConvert.SerializeObject(v), // Convert to JSON string
                v => JsonConvert.DeserializeObject<Dictionary<string, object>>(v)) // Convert from JSON string
            .HasColumnType("nvarchar(max)");

        modelBuilder.Entity<ProductEntity>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18,4)");
    }
}
