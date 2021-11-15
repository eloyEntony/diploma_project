using Ecommerce.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities
{
    public class ProductEntity:BaseEntity<long>
    {
        [StringLength(450)]
        public string ShortDescription { get; set; }        

        public string Description { get; set; }

        public string Link { get; set; }

        public string Specification { get; set; }

        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }

        public long? BrandId { get; set; }
        public BrandEntity Brand { get; set; }


        public long? CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }

        public IList<ProductAttributeValue> AttributeValues { get; protected set; }


        public ProductEntity()
        {
            AttributeValues = new List<ProductAttributeValue>();
        }

    }
}
