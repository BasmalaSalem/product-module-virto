using BaseProductModule.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalProductModule.Data.Model;

public class PhysicalProductEntity : ProductEntity
{
    public int Stock { get; set; }
}
