using BaseProductModule.Core.Model;
using BaseProductModule.Data.Model;
using PhysicalProductModule.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Domain;

namespace PhysicalProductModule.Data.Model;

public class PhysicalProductEntity : ProductEntity , IDataEntity<PhysicalProductEntity,PhysicalProduct>
{
    public int Stock { get; set; }

    public PhysicalProductEntity FromModel(PhysicalProduct model, PrimaryKeyResolvingMap pkMap)
    {
        pkMap.AddPair(model, this);

        Id = model.Id;
        Name = model.Name;
        Description = model.Description;
        Price = model.Price;
        DynamicProperty = model.DynamicProperty;
        Stock = model.Stock;
        return this;
    }

    public void Patch(PhysicalProductEntity target)
    {
        target.Name = Name;
        target.Description = Description;
        target.Price = Price;
        target.DynamicProperty = DynamicProperty;
        target.Stock = Stock;
    }

    public PhysicalProduct ToModel(PhysicalProduct model)
    {
        model.Id = Id;
        model.Name = Name;
        model.Description = Description;
        model.Price = Price;
        model.DynamicProperty = DynamicProperty;
        model.Stock = Stock;
        return model;
    }
}
