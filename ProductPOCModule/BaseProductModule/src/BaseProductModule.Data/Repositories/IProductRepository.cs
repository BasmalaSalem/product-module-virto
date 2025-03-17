using BaseProductModule.Core.Model;
using VirtoCommerce.Platform.Core.Common;

namespace BaseProductModule.Data.Repositories;

public interface IProductRepository<T> : IRepository
{
    public Task<T> GetProductByIdAsync(string id);
    public Task<List<T>> GetProductsAsync();
    public Task DeleteProductByIdAsync(string id);
    public Task<T> UpdateProductAsync(string id, T product);
    public Task<T> CreateProductAsync(T product);
}
