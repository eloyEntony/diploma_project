using Ecommerce.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities
{
    public class ProductAttribute : BaseEntity <long>
    {

        public long GroupId { get; set; }

        public virtual ProductAttributeGroup Group { get; set; }

        public virtual IList<ProductAttributeValue> Products { get; set; }

    }
}
