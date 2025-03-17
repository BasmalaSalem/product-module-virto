using BaseProductModule.Core.Model;
using VirtoCommerce.Platform.Core.Common;

namespace BaseProductModule.Data.Repositories;

public interface IProductRepository : IRepository
{
    Task<Product> GetProductByIdAsync(string id);
    Task<List<Product>> GetProductsAsync();
    Task DeleteProductByIdAsync(string id);
    Task<Product> UpdateProductAsync(string id, Product product);
    Task<Product> CreateProductAsync(Product product);
}
