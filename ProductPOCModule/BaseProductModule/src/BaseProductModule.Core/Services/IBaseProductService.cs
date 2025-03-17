using BaseProductModule.Core.Model;

namespace BaseProductModule.Core.Services;

public interface IBaseProductService<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<List<T>> GetAllAsync();
    Task<T> CreateAsync(T product);
    Task<T> UpdateAsync(string id, T product);
    Task DeleteAsync(int id);
}
