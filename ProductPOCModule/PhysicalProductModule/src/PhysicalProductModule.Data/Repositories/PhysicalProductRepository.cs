using BaseProductModule.Core.Model;
using BaseProductModule.Data.Model;
using BaseProductModule.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using PhysicalProductModule.Core.Model;
using PhysicalProductModule.Data.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace PhysicalProductModule.Data.Repositories;

public class PhysicalProductRepository : DbContextRepositoryBase<PhysicalProductDbContext>, IProductRepository<PhysicalProduct>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public PhysicalProductRepository(PhysicalProductDbContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// Gets the queryable collection of <see cref="ProductEntity"/>.
    /// </summary>
    public IQueryable<PhysicalProductEntity> Products => DbContext.Set<PhysicalProductEntity>();

    /// <inheritdoc />
    public virtual async Task<PhysicalProduct> GetByIdAsync(string id)
    {
        var productEntity = await Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productEntity is null)
        {
            throw new KeyNotFoundException($"Product with id '{id}' not found.");
        }
        return productEntity.ToModel(new PhysicalProduct());
    }

    /// <inheritdoc />
    public virtual async Task<List<PhysicalProduct>> GetAllAsync()
    {
        var productsEntity = await Products.ToListAsync();

        if (productsEntity is null)
        {
            throw new KeyNotFoundException("No products found.");
        }

        return productsEntity.Select(e => e.ToModel(new PhysicalProduct())).ToList();
    }

    /// <inheritdoc />
    public virtual async Task DeleteAsync(string id)
    {
        var productEntity = await Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productEntity is null)
        {
            throw new KeyNotFoundException($"Product with id '{id}' not found.");
        }

        DbContext.Set<ProductEntity>().Remove(productEntity);
        await DbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public virtual async Task<PhysicalProduct> UpdateAsync(string id, PhysicalProduct product)
    {
        var productEntity = await Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productEntity is null)
        {
            throw new KeyNotFoundException($"Product with id '{id}' not found.");
        }

        var updatedEntity = new PhysicalProductEntity().FromModel(product, new PrimaryKeyResolvingMap());

        // Apply changes using the Patch method
        updatedEntity.Patch(productEntity);

        DbContext.Set<PhysicalProductEntity>().Update(productEntity);
        await DbContext.SaveChangesAsync();

        return productEntity.ToModel(product);
    }

    /// <inheritdoc />
    public virtual async Task<PhysicalProduct> CreateAsync(PhysicalProduct product)
    {
        var entity = new PhysicalProductEntity().FromModel(product, new PrimaryKeyResolvingMap());

        DbContext.Set<PhysicalProductEntity>().Add(entity);

        await DbContext.SaveChangesAsync();

        return entity.ToModel(product);
    }
}
