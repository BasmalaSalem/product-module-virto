using BaseProductModule.Core.Model;
using BaseProductModule.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProductModule.Data.Services;

public class BaseProductService : IBaseProductService
{
    public Task<Product> CreateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateAsync(string id, Product product)
    {
        throw new NotImplementedException();
    }
}
