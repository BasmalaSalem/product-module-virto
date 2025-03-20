using BaseProductModule.Core.Services;
using BaseProductModule.Data.Repositories;
using PhysicalProductModule.Core.Model;

namespace PhysicalProductModule.Data.Services;

/// <summary>
/// Provides concrete implementation of product management operations using a repository pattern
/// </summary>
/// <remarks>
/// This service delegates data persistence operations to an <see cref="IProductRepository"/> implementation
/// </remarks>
public class PhysicalProductService : IBaseProductService<PhysicalProduct>
{
    private readonly IProductRepository<PhysicalProduct> _productRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="PhysicalProductService"/> class
    /// </summary>
    /// <param name="productRepository">The product repository dependency</param>
    public PhysicalProductService(IProductRepository<PhysicalProduct> productRepository)
    {
        _productRepository = productRepository;
    }

    /// <inheritdoc/>
    /// <remarks>
    /// This implementation delegates to the repository's <see cref="IProductRepository.CreateAsync"/> method
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the provided product is null</exception>
    public async Task<PhysicalProduct> CreateProductAsync(PhysicalProduct product)
    {
        return await _productRepository.CreateAsync(product);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Converts the integer ID to string before delegating to the repository's <see cref="IProductRepository.DeleteAsync"/> method
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when the conversion to string ID fails validation</exception>
    public async Task DeleteProductAsync(string id)
    {
        await _productRepository.DeleteAsync(id);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Returns all products through the repository's <see cref="IProductRepository.GetAllAsync"/> method
    /// </remarks>
    public async Task<List<PhysicalProduct>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Uses the repository's <see cref="IProductRepository.GetByIdAsync"/> method for product lookup
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the id parameter is null or empty</exception>
    public async Task<PhysicalProduct> GetProductByIdAsync(string id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Delegates update operations to the repository's <see cref="IProductRepository.UpdateAsync"/> method
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when either the id or product parameters are null</exception>
    /// <exception cref="ArgumentException">Thrown when the id does not match the product identifier</exception>
    public async Task<PhysicalProduct> UpdateProductAsync(string id, PhysicalProduct product)
    {
        return await _productRepository.UpdateAsync(id, product);
    }
}