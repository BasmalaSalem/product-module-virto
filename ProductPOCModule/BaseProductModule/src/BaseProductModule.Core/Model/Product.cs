using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VirtoCommerce.Platform.Core.Common;

namespace BaseProductModule.Core.Model;

/// <summary>
/// Represents a product with its details.
/// </summary>
public class Product : AuditableEntity, ICloneable
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets additional metadata for the product.
    /// </summary>
   
    public Dictionary<string, string> DynamicProperty { get; set; } = new Dictionary<string, string>();


    /// <summary>
    /// Creates a shallow copy of the current product instance.
    /// </summary>
    /// <returns>A cloned instance of the product.</returns>
    public object Clone() => MemberwiseClone();
}
