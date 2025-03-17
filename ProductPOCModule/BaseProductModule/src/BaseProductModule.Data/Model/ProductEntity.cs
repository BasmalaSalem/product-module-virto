using BaseProductModule.Core.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Domain;

namespace BaseProductModule.Data.Model;

public class ProductEntity : AuditableEntity, IDataEntity<ProductEntity, Product>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public Dictionary<string, object> MetaData { get; set; } = new Dictionary<string, object>();

    public ProductEntity FromModel(Product model, PrimaryKeyResolvingMap pkMap)
    {
        pkMap.AddPair(model, this);

        Id = model.Id;
        Name = model.Name;
        Description = model.Description;
        Price = model.Price;
        MetaData = model.MetaData;
        return this;

    }

    public void Patch(ProductEntity target)
    {
        target.Name = Name;
        target.Description = Description;
        target.Price = Price;
        target.MetaData = MetaData;
    }

    public Product ToModel(Product model)
    {
        model.Id = Id;
        model.Name = Name;
        model.Description = Description;
        model.Price = Price;
        model.MetaData = MetaData;
        return model;
    }
}