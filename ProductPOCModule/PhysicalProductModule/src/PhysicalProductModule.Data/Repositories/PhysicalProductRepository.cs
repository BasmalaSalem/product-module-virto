using BaseProductModule.Core.Model;
using BaseProductModule.Data.Model;
using Microsoft.EntityFrameworkCore;
using PhysicalProductModule.Core.Model;
using PhysicalProductModule.Data.Model;
using PhysicalProductModule.Data.Repositories;

namespace BaseProductModule.Data.Repositories;

public class PhysicalProductRepository : ProductRepository
{
    public PhysicalProductRepository(PhysicalProductDbContext dbContext) : base(dbContext)
    {

    }

}
