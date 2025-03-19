using BaseProductModule.Data.Model;
using BaseProductModule.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PhysicalProductModule.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalProductModule.Data.Repositories;

public class PhysicalProductDbContext : BaseProductDbContext
{
    public PhysicalProductDbContext(DbContextOptions<PhysicalProductDbContext> options) : base(options)
    {
    }
    protected PhysicalProductDbContext(DbContextOptions options)
  : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhysicalProductEntity>()
            .ToTable("PhysicalProduts");

        modelBuilder.Entity<PhysicalProductEntity>()
       .Property(p => p.MetaData)
       .HasConversion(
           v => JsonConvert.SerializeObject(v),  // Serialize Dictionary to JSON string
           v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v) // Deserialize JSON string to Dictionary
       );


       modelBuilder.Entity<ProductEntity>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18,4)");
    }
}
