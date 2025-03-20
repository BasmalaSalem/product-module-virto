using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace BaseProductModule.Data.Repositories;

/// <summary>
/// Factory for creating an instance of <see cref="BaseProductDbContext"/> at design time.
/// </summary>
public class BaseSqlServerDbContextFactory : IDesignTimeDbContextFactory<BaseProductDbContext>
{
    /// <summary>
    /// Creates a new instance of <see cref="BaseProductDbContext"/> with the specified arguments.
    /// </summary>
    /// <param name="args">Optional arguments, such as a connection string.</param>
    /// <returns>A new instance of <see cref="BaseProductDbContext"/> configured for SQL Server.</returns>
    public BaseProductDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<BaseProductDbContext>();

        var connectionString = args.Length != 0
            ? args[0]
            //: "Data Source=(local);Initial Catalog=VirtoCommerce3.net8;Persist Security Info=True;User ID=Mixed mode;Password=123;Connect Timeout=30;TrustServerCertificate=True;";
            : "Data Source=(local);Initial Catalog=VirtoCommerce3.net8;Persist Security Info=True;User ID=virto;Password=virto;Connect Timeout=30;TrustServerCertificate=True;";

        builder.UseSqlServer(
            connectionString,
            db => db.MigrationsAssembly(typeof(SqlServerDataAssemblyMarker).Assembly.GetName().Name));

        return new BaseProductDbContext(builder.Options);
    }
}
