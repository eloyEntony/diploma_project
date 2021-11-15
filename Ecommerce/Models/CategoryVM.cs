using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class CategorySlimVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? CatalogId { get; set; }
        public IList<CategorySlimVM> Children { get; set; }

    }
}
