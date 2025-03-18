using Microsoft.EntityFrameworkCore;
using PhysicalProductModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.SqlServer.Extensions;

namespace PhysicalProductModule.Web;

public class Module : IModule , IHasConfiguration
{
    public ManifestModuleInfo ModuleInfo { get ; set ; }
    public IConfiguration Configuration { get ; set ; }

    public void Initialize(IServiceCollection serviceCollection)
    {
        var connectionString = Configuration.GetConnectionString(ModuleInfo.Id) ?? Configuration.GetConnectionString("VirtoCommerce");

        serviceCollection.AddDbContext<PhysicalProductDbContext>(options =>
            options.UseSqlServerDatabase(connectionString, typeof(SqlServerDataAssemblyMarker), Configuration));
    }

    public void PostInitialize(IApplicationBuilder appBuilder)
    {
        var serviceProvider = appBuilder.ApplicationServices;

        // Apply migrations
        using var serviceScope = serviceProvider.CreateScope();

        using var dbContext = serviceScope.ServiceProvider.GetRequiredService<PhysicalProductDbContext>();

        dbContext.Database.Migrate();
    }

    public void Uninstall()
    {
        throw new NotImplementedException();
    }
}
