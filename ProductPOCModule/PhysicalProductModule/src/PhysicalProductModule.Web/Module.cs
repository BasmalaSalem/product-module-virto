using BaseProductModule.Core.Model;
using BaseProductModule.Core.Services;
using BaseProductModule.Data.Model;
using BaseProductModule.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using PhysicalProductModule.Core.Model;
using PhysicalProductModule.Data.Model;
using PhysicalProductModule.Data.Repositories;
using PhysicalProductModule.Data.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.JsonConverters;
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
            options.UseSqlServerDatabase(connectionString, typeof(Data.Repositories.SqlServerDataAssemblyMarker), Configuration));
    
       serviceCollection.AddTransient<IProductRepository<PhysicalProduct>, PhysicalProductRepository>();

       serviceCollection.AddTransient<IBaseProductService<PhysicalProduct>, PhysicalProductService>();


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
