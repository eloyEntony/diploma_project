using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities
{
    public class ProductAttributeGroup : BaseEntity<long>
    {

        public IList<ProductAttribute> Attributes { get; set; } 

        public long? CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }

        public ProductAttributeGroup()
        {
            Attributes = new List<ProductAttribute>();
        }

    }
}
