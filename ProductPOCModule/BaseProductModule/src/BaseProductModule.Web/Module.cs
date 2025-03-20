using BaseProductModule.Data.Repositories;
using VirtoCommerce.Platform.Data.SqlServer.Extensions;
using VirtoCommerce.Platform.Core.Modularity;
using Microsoft.EntityFrameworkCore;
using BaseProductModule.Core.Services;
using BaseProductModule.Data.Services;
using BaseProductModule.Core.Model;

namespace BaseProductModule.Web;

/// <summary>
/// Main entry point for the Base Product Module
/// </summary>
/// <remarks>
/// Configures and initializes module components including database context, services, 
/// and applies database migrations during startup
/// </remarks>
public class Module : IModule, IHasConfiguration
{
    /// <summary>
    /// Gets or sets the module manifest information
    /// </summary>
    public ManifestModuleInfo ModuleInfo { get; set; }

    /// <summary>
    /// Gets or sets the application configuration
    /// </summary>
    public IConfiguration Configuration { get; set; }

    /// <summary>
    /// Initializes module services and dependencies
    /// </summary>
    /// <param name="serviceCollection">The service collection to configure</param>
    /// <remarks>
    /// Configures the following services:
    /// <list type="bullet">
    /// <item><description>Entity Framework Core database context with SQL Server provider</description></item>
    /// <item><description>Product repository implementation</description></item>
    /// <item><description>Base product service implementation</description></item>
    /// </list>
    /// </remarks>
    public void Initialize(IServiceCollection serviceCollection)
    {
        var connectionString = Configuration.GetConnectionString(ModuleInfo.Id) ?? Configuration.GetConnectionString("VirtoCommerce");

        serviceCollection.AddDbContext<BaseProductDbContext>(options =>
            options.UseSqlServerDatabase(connectionString, typeof(SqlServerDataAssemblyMarker), Configuration));

        serviceCollection.AddTransient<IProductRepository<Product>, ProductRepository>();

        // Register services
        serviceCollection.AddTransient<IBaseProductService<Product>, BaseProductService>();
    }

    /// <summary>
    /// Post-initialization hook for applying database migrations
    /// </summary>
    /// <param name="appBuilder">The application builder</param>
    /// <remarks>
    /// Applies any pending Entity Framework Core migrations for the module's database context
    /// during application startup
    /// </remarks>
    public void PostInitialize(IApplicationBuilder appBuilder)
    {
        var serviceProvider = appBuilder.ApplicationServices;

        // Apply migrations
        using var serviceScope = serviceProvider.CreateScope();

        using var dbContext = serviceScope.ServiceProvider.GetRequiredService<BaseProductDbContext>();

        dbContext.Database.Migrate();
    }

    /// <summary>
    /// Handles module uninstallation (Not Implemented)
    /// </summary>
    /// <exception cref="NotImplementedException">Always thrown as uninstall is not supported</exception>
    public void Uninstall()
    {
        throw new NotImplementedException();
    }
}