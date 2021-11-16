using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Specification { get; set; }
        public decimal Price { get; set; }
        public long? BrandId { get; set; }
        public long? CategoryId { get; set; }

        public IList<AttributeSlimVM> Attributes { get; set; }
    }
}
