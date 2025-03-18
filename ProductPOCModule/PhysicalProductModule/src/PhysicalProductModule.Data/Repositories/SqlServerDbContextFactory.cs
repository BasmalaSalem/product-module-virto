using BaseProductModule.Data.Repositories;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalProductModule.Data.Repositories;

public class SqlServerDbContextFactory : IDesignTimeDbContextFactory<PhysicalProductDbContext>
{
    public PhysicalProductDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<PhysicalProductDbContext>();
        var connectionString = args.Length != 0 ? args[0] : "Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=sa;Password=123;Connect Timeout=30;TrustServerCertificate=True;";

        builder.UseSqlServer(
            connectionString,
            db => db.MigrationsAssembly(typeof(SqlServerDataAssemblyMarker).Assembly.GetName().Name));


        return new PhysicalProductDbContext(builder.Options);
    }
}
