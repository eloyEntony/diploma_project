using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities.Product
{
    public class ProductAttributeValue
    {
        public long ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public long AttributeId { get; set; }
        public ProductAttribute Attribute { get; set; }
    }
}
