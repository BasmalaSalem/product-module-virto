using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace BaseProductModule.Core.Model;

public class Product : AuditableEntity , ICloneable 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public object Clone() => MemberwiseClone();

}
