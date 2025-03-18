using BaseProductModule.Core.Model;
using BaseProductModule.Data.Model;
using Microsoft.EntityFrameworkCore;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProductModule.Data.Repositories;

/// <summary>
/// Repository implementation for managing product data in the database.
/// </summary>
public class ProductRepository : DbContextRepositoryBase<BaseProductDbContext>, IProductRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public ProductRepository(BaseProductDbContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// Gets the queryable collection of <see cref="ProductEntity"/>.
    /// </summary>
    public IQueryable<ProductEntity> Products => DbContext.Set<ProductEntity>();

    /// <inheritdoc />
    public virtual async Task<Product> GetByIdAsync(string id)
    {
        var productEntity = await Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productEntity is null)
        {
            throw new KeyNotFoundException($"Product with id '{id}' not found.");
        }
        return productEntity.ToModel(new Product());
    }

    /// <inheritdoc />
    public virtual async Task<List<Product>> GetAllAsync()
    {
        var productsEntity = await Products.ToListAsync();

        if (productsEntity is null || !productsEntity.Any())
        {
            throw new KeyNotFoundException("No products found.");
        }

        return productsEntity.Select(e => e.ToModel(new Product())).ToList();
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
    public virtual async Task<Product> UpdateAsync(string id, Product product)
    {
        var productEntity = await Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productEntity is null)
        {
            throw new KeyNotFoundException($"Product with id '{id}' not found.");
        }

        var updatedEntity = new ProductEntity().FromModel(product, new PrimaryKeyResolvingMap());

        // Apply changes using the Patch method
        updatedEntity.Patch(productEntity);

        DbContext.Set<ProductEntity>().Update(productEntity);
        await DbContext.SaveChangesAsync();

        return productEntity.ToModel(product);
    }

    /// <inheritdoc />
    public virtual async Task<Product> CreateAsync(Product product)
    {
        var entity = new ProductEntity().FromModel(product, new PrimaryKeyResolvingMap());

        DbContext.Set<ProductEntity>().Add(entity);
        await DbContext.SaveChangesAsync();

        return entity.ToModel(product);
    }
}
