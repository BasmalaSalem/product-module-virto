using BaseProductModule.Data.Repositories;
using VirtoCommerce.Platform.Data.SqlServer.Extensions;
using VirtoCommerce.Platform.Core.Modularity;
using Microsoft.EntityFrameworkCore;
using BaseProductModule.Core.Services;
using BaseProductModule.Data.Services;

namespace BaseProductModule.Web;

public class Module : IModule , IHasConfiguration
{
    public ManifestModuleInfo ModuleInfo { get ; set ; }
    public IConfiguration Configuration { get ; set ; }

    public void Initialize(IServiceCollection serviceCollection)
    {
        var connectionString = Configuration.GetConnectionString(ModuleInfo.Id) ?? Configuration.GetConnectionString("VirtoCommerce");

        serviceCollection.AddDbContext<BaseProductDbContext>(options =>
            options.UseSqlServerDatabase(connectionString, typeof(SqlServerDataAssemblyMarker), Configuration));

        serviceCollection.AddTransient<IProductRepository, ProductRepository>();

        // Register services
        serviceCollection.AddTransient<IBaseProductService, BaseProductService>();
    }

    public void PostInitialize(IApplicationBuilder appBuilder)
    {
        var serviceProvider = appBuilder.ApplicationServices;

        // Apply migrations
        using var serviceScope = serviceProvider.CreateScope();
       
        using var dbContext = serviceScope.ServiceProvider.GetRequiredService<BaseProductDbContext>();

        dbContext.Database.Migrate();
    }

    public void Uninstall()
    {
        throw new NotImplementedException();
    }
}
