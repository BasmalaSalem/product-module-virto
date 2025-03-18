using BaseProductModule.Core.Model;
using BaseProductModule.Core.Services;
using BaseProductModule.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProductModule.Data.Services;

/// <summary>
/// Provides concrete implementation of product management operations using a repository pattern
/// </summary>
/// <remarks>
/// This service delegates data persistence operations to an <see cref="IProductRepository"/> implementation
/// </remarks>
public class BaseProductService : IBaseProductService
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseProductService"/> class
    /// </summary>
    /// <param name="productRepository">The product repository dependency</param>
    public BaseProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <inheritdoc/>
    /// <remarks>
    /// This implementation delegates to the repository's <see cref="IProductRepository.CreateAsync"/> method
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the provided product is null</exception>
    public async Task<Product> CreateProductAsync(Product product)
    {
        return await _productRepository.CreateAsync(product);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Converts the integer ID to string before delegating to the repository's <see cref="IProductRepository.DeleteAsync"/> method
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when the conversion to string ID fails validation</exception>
    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteAsync(id.ToString());
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Returns all products through the repository's <see cref="IProductRepository.GetAllAsync"/> method
    /// </remarks>
    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Uses the repository's <see cref="IProductRepository.GetByIdAsync"/> method for product lookup
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the id parameter is null or empty</exception>
    public async Task<Product> GetProductByIdAsync(string id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Delegates update operations to the repository's <see cref="IProductRepository.UpdateAsync"/> method
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when either the id or product parameters are null</exception>
    /// <exception cref="ArgumentException">Thrown when the id does not match the product identifier</exception>
    public async Task<Product> UpdateProductAsync(string id, Product product)
    {
        return await _productRepository.UpdateAsync(id, product);
    }
}