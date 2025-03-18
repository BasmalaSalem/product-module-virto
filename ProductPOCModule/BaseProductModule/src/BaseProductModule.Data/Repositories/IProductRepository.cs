using BaseProductModule.Core.Model;
using VirtoCommerce.Platform.Core.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseProductModule.Data.Repositories;

/// <summary>
/// Defines a repository interface for managing product data.
/// </summary>
public interface IProductRepository : IRepository
{
    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the product.</returns>
    Task<Product> GetByIdAsync(string id);

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all products.</returns>
    Task<List<Product>> GetAllAsync();

    /// <summary>
    /// Deletes a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteAsync(string id);

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The unique identifier of the product to update.</param>
    /// <param name="product">The updated product details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated product.</returns>
    Task<Product> UpdateAsync(string id, Product product);

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="product">The product details to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created product.</returns>
    Task<Product> CreateAsync(Product product);
}
