using BaseProductModule.Core.Model;
using VirtoCommerce.Platform.Core.Common;

namespace BaseProductModule.Data.Repositories;

public interface IProductRepository : IRepository
{
    public Task<Product> GetByIdAsync(string id);
    public Task<List<Product>> GetAllAsync();
    public Task DeleteAsync(string id);
    public Task<Product> UpdateAsync(string id, Product product);
    public Task<Product> CreateAsync(Product product);
}
