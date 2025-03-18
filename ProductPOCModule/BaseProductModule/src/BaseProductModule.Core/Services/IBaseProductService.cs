using BaseProductModule.Core.Model;

namespace BaseProductModule.Core.Services;

/// <summary>
/// Provides base operations for product management including CRUD operations
/// </summary>
public interface IBaseProductService
{
    /// <summary>
    /// Retrieves a single product by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product to retrieve</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation, containing the found product or null</returns>
    Task<Product> GetProductByIdAsync(string id);

    /// <summary>
    /// Retrieves all available products from the system
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation, containing a list of all products</returns>
    Task<List<Product>> GetAllProductsAsync();

    /// <summary>
    /// Creates a new product in the system
    /// </summary>
    /// <param name="product">The product entity to create</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation, containing the created product with generated identifier</returns>
    /// <exception cref="ArgumentException">Thrown when provided product data is invalid</exception>
    Task<Product> CreateProductAsync(Product product);

    /// <summary>
    /// Updates an existing product with new data
    /// </summary>
    /// <param name="id">The unique identifier of the product to update</param>
    /// <param name="product">The product data containing updated values</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation, containing the updated product entity</returns>
    /// <exception cref="KeyNotFoundException">Thrown when no product exists with the specified identifier</exception>
    /// <exception cref="ArgumentException">Thrown when provided product data is invalid</exception>
    Task<Product> UpdateProductAsync(string id, Product product);

    /// <summary>
    /// Permanently deletes a product from the system
    /// </summary>
    /// <param name="id">The numeric identifier of the product to delete</param>
    /// <returns>A <see cref="Task"/> representing the completion of the asynchronous operation</returns>
    /// <exception cref="KeyNotFoundException">Thrown when no product exists with the specified identifier</exception>
    Task DeleteProductAsync(string id);
}