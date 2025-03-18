using BaseProductModule.Core.Model;

namespace BaseProductModule.Core.Services;

public interface IBaseProductService 
{
    Task<Product> GetProductByIdAsync(string id);
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(string id, Product product);
    Task DeleteProductAsync(int id);
}
