using BaseProductModule.Core.Model;
using BaseProductModule.Data.Model;
using Microsoft.EntityFrameworkCore;
using PhysicalProductModule.Core.Model;
using PhysicalProductModule.Data.Model;
using PhysicalProductModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Common;

namespace BaseProductModule.Data.Repositories;

public class PhysicalProductRepository : ProductRepository
{
    private readonly DbSet<PhysicalProductEntity> PhysicalProducts;
    public PhysicalProductRepository(PhysicalProductDbContext dbContext) : base(dbContext)
    {
        PhysicalProducts = dbContext.Set<PhysicalProductEntity>();
    }

    public override async Task<Product> GetByIdAsync(string id)
    {
        var product = await base.GetByIdAsync(id);

        // Get the physical product entity with all properties
        var entity = await PhysicalProducts
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is PhysicalProduct physicalProduct && entity != null)
        {
            // Map physical-specific properties
            physicalProduct.Stock = entity.Stock;
            // Map other physical properties here
        }

        return product;
    }

    public override async Task<Product> CreateAsync(Product product)
    {
        var result = await base.CreateAsync(product);

        if (product is PhysicalProduct physicalProduct)
        {
            var physical = new PhysicalProductEntity
            {
                Stock = physicalProduct.Stock,
            };

            PhysicalProducts.Add(physical);

            await DbContext.SaveChangesAsync();
        }

        return result;
    }

    public override async Task<Product> UpdateAsync(string id, Product product)
    {
        var result = await base.UpdateAsync(id, product);

        if (product is PhysicalProduct physicalProduct)
        {
            var physical = await PhysicalProducts
                .FirstOrDefaultAsync(p => p.Id == id);

            if (physical != null)
            {
                physical.Stock = physicalProduct.Stock;
                
                await DbContext.SaveChangesAsync();
            }
        }

        return result;
    }

    //public override async Task<List<Product>> GetAllAsync()
    //{
    //    var products = await base.GetAllAsync();
    //    var entity = await PhysicalProducts.OfType<PhysicalProduct>().ToListAsync();

    //}

    /// <inheritdoc />
    public override async Task DeleteAsync(string id)
    {
        await base.DeleteAsync(id);

       var physicalProduct = await PhysicalProducts.FirstOrDefaultAsync(p => p.Id == id);
        if (physicalProduct != null)
        {
            PhysicalProducts.Remove(physicalProduct);

            await DbContext.SaveChangesAsync();
        }

    }

}
