using BaseProductModule.Core.Model;

namespace BaseProductModule.Core.Services;

public interface IBaseProductService
{
    Task<Product> GetByIdAsync(string id);
    Task<List<Product>> GetAllAsync();
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(string id, Product product);
    Task DeleteAsync(int id);
}
