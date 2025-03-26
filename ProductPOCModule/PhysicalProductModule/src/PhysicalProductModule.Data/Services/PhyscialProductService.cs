using BaseProductModule.Core.Model;
using BaseProductModule.Core.Services;
using BaseProductModule.Data.Services;
using PhysicalProductModule.Core.Model;
using PhysicalProductModule.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace PhysicalProductModule.Data.Services;

public class PhyscialProductService : BaseProductService
{
    private readonly IPhyscialProductRepository _physcialProductRepository;
    public PhyscialProductService(IPhyscialProductRepository physcialProductRepository)
    {
        _physcialProductRepository = physcialProductRepository;
    }
    public override async Task<Product> CreateProductAsync(Product product)
    {
        if (product is PhysicalProduct physicalProduct )
        {
            return await _physcialProductRepository.CreateAsync(physicalProduct);
        }
        return await base.CreateProductAsync(product);
    }

    public override async Task DeleteProductAsync(string id)
    {
        var product = await base.GetProductByIdAsync(id);

        if (product is PhysicalProduct physicalProduct)
        {
            await _physcialProductRepository.DeleteAsync(id);
        }
    }

    public override async Task<List<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public override async Task<Product> GetProductByIdAsync(string id)
    {
        var product = await base.GetProductByIdAsync(id);

        if (product is PhysicalProduct physicalProduct)
        {
           return await _physcialProductRepository.GetByIdAsync(id);
        }
        return product;
    }

    public override async Task<Product> UpdateProductAsync(string id, Product product)
    {
        if (product is PhysicalProduct physicalProduct)
        {
            await _physcialProductRepository.UpdateAsync(id,physicalProduct);
        }
        return await base.UpdateProductAsync(id, product);
    }
}
