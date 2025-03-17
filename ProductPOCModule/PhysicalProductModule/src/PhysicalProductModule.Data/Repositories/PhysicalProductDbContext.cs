using BaseProductModule.Data.Model;
using BaseProductModule.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using PhysicalProductModule.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalProductModule.Data.Repositories;

public class PhysicalProductDbContext : BaseProductDbContext
{
    public PhysicalProductDbContext(DbContextOptions<BaseProductDbContext> options) : base(options)
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
        .Property(p => p.Price)
        .HasColumnType("decimal(18,4)");
    }
}
