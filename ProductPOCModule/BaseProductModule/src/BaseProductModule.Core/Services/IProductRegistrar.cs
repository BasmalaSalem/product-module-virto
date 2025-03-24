using BaseProductModule.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProductModule.Core.Services;

public interface IProductRegistrar 
{
    void RegisterProduct<T>(Func<T> factory = null) where T : Product;
    Task<Product[]> GetRegisteredProducts();
}
