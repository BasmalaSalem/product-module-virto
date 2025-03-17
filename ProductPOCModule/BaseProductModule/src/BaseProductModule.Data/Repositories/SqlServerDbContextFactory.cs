using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProductModule.Data.Repositories;

public class SqlServerDbContextFactory : IDesignTimeDbContextFactory<BaseProductDbContext>
{
    public BaseProductDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<BaseProductDbContext>();
        var connectionString = args.Length != 0 ? args[0] : "Data Source=(local);Initial Catalog=VirtoCommerce3;Persist Security Info=True;User ID=Mixed mode;Password=123;Connect Timeout=30;TrustServerCertificate=True;";

        builder.UseSqlServer(
            connectionString,
            db => db.MigrationsAssembly(typeof(SqlServerDataAssemblyMarker).Assembly.GetName().Name));


        return new BaseProductDbContext(builder.Options);
    }
}
