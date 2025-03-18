using BaseProductModule.Core.Model;
using BaseProductModule.Data.Model;
using Microsoft.EntityFrameworkCore;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace BaseProductModule.Data.Repositories;

public class ProductRepository : DbContextRepositoryBase<BaseProductDbContext>, IProductRepository
{
    public ProductRepository(BaseProductDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<ProductEntity> Products => DbContext.Set<ProductEntity>();
    public virtual async Task<Product> GetByIdAsync(string id)
    {
        var productEntity = await Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productEntity is null)
        {
            throw new KeyNotFoundException($"Product with id '{id}' not found.");
        }
        return productEntity.ToModel(new Product());
    }

    public virtual async Task<List<Product>> GetAllAsync()
    {
        var productsEntity= await Products.ToListAsync();

        if (productsEntity is null)
        {
            throw new KeyNotFoundException($"Products not found.");
        }

        var products = productsEntity.Select(e => e.ToModel(new Product())).ToList();

        return products;
    }

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

    public virtual async Task<Product> CreateAsync(Product product)
    {
        var entity = new ProductEntity().FromModel(product, new PrimaryKeyResolvingMap());

        DbContext.Set<ProductEntity>().Add(entity);
    
        await DbContext.SaveChangesAsync();

        return entity.ToModel(product);
    }
}