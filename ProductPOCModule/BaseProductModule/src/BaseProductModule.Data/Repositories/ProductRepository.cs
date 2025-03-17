using BaseProductModule.Core.Model;
using BaseProductModule.Data.Model;
using Microsoft.EntityFrameworkCore;
using VirtoCommerce.Platform.Data.Infrastructure;

namespace BaseProductModule.Data.Repositories;

public class ProductRepository : DbContextRepositoryBase<BaseProductDbContext>, IProductRepository
{
    public ProductRepository(BaseProductDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<ProductEntity> Products => DbContext.Set<ProductEntity>();
    public virtual async Task<Product> GetProductByIdAsync(string id)
    {
        var productEntity = await Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productEntity is null)
        {
            throw new KeyNotFoundException($"Product with id '{id}' not found.");
        }

        var product = new Product { Name = productEntity.Name, Description = productEntity.Description, Price = productEntity.Price };
        
        return product;
    }

    public virtual async Task<List<Product>> GetProductsAsync()
    {
        var productsEntity = await Products.ToListAsync();

        if (productsEntity is null)
        {
            throw new KeyNotFoundException($"Products not found.");
        }

        var products = productsEntity.Select(p => new Product { Name = p.Name, Description = p.Description, Price = p.Price }).ToList();
        
        return products;
    }

    public virtual async Task DeleteProductByIdAsync(string id)
    {
        var productEntity = await Products.FirstOrDefaultAsync(p => p.Id == id);
        if (productEntity == null)
        {
            throw new KeyNotFoundException($"Product with id '{id}' not found.");
        }
        DbContext.Remove(productEntity);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task<Product> UpdateProductAsync(string id, Product product)
    {
        var productEntity = await Products.FirstOrDefaultAsync(p => p.Id == id);
        if (productEntity == null)
        {
            throw new KeyNotFoundException($"Product with id '{id}' not found.");
        }
        productEntity.Name = product.Name;
        productEntity.Price = product.Price;
        productEntity.Description = product.Description;

        await DbContext.SaveChangesAsync();
        return product;
    }

    public virtual async Task<Product> CreateProductAsync(Product product)
    {
        var entity = new ProductEntity
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };

        DbContext.Add(entity);

        await DbContext.SaveChangesAsync();

        return product;
    }
}
