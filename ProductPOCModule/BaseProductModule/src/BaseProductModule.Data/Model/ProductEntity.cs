using BaseProductModule.Core.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Domain;

namespace BaseProductModule.Data.Model;

/// <summary>
/// Represents the database entity for a product.
/// </summary>
public class ProductEntity : AuditableEntity, IDataEntity<ProductEntity, Product>
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets additional metadata for the product.
    /// </summary>
    public Dictionary<string, string> DynamicProperty { get; set; } = new Dictionary<string, string>();

    
    /// <summary>
    /// Maps data from a <see cref="Product"/> model to this entity.
    /// </summary>
    /// <param name="model">The product model to map from.</param>
    /// <param name="pkMap">The primary key resolving map for maintaining relationships.</param>
    /// <returns>The updated <see cref="ProductEntity"/> instance.</returns>
    public ProductEntity FromModel(Product model, PrimaryKeyResolvingMap pkMap)
    {
        pkMap.AddPair(model, this);

        Id = model.Id;
        Name = model.Name;
        Description = model.Description;
        Price = model.Price;
        DynamicProperty = model.DynamicProperty;
        return this;
    }

    /// <summary>
    /// Applies changes from this entity to the target entity.
    /// </summary>
    /// <param name="target">The target <see cref="ProductEntity"/> to apply changes to.</param>
    public void Patch(ProductEntity target)
    {
        target.Name = Name;
        target.Description = Description;
        target.Price = Price;
        target.DynamicProperty = DynamicProperty;
    }

    /// <summary>
    /// Converts this entity to a <see cref="Product"/> model.
    /// </summary>
    /// <param name="model">The product model to populate.</param>
    /// <returns>The populated <see cref="Product"/> model.</returns>
    public Product ToModel(Product model)
    {
        model.Id = Id;
        model.Name = Name;
        model.Description = Description;
        model.Price = Price;
        model.DynamicProperty = DynamicProperty;
        return model;
    }
}
