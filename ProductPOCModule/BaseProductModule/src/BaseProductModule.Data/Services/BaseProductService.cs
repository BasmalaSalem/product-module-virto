using BaseProductModule.Core.Model;
using BaseProductModule.Core.Services;
using BaseProductModule.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProductModule.Data.Services;

public class BaseProductService : IBaseProductService
{
    private readonly IProductRepository _productRepository;
    public BaseProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        return await _productRepository.CreateAsync(product);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }



    public async Task<Product> GetProductByIdAsync(string id)
    {

        return await _productRepository.GetByIdAsync(id);

    }

    public async Task<Product> UpdateProductAsync(string id, Product product)
    {
        return await _productRepository.UpdateAsync(id, product);

    }

}
