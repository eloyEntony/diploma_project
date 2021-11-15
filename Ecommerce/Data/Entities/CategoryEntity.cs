using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities
{
    public class CategoryEntity:BaseEntity<long>
    {
        
        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        public bool IncludeInMenu { get; set; }


        public long? ParentId { get; set; }

        public virtual CategoryEntity Parent { get; set; }


        public IList<CategoryEntity> Children { get; protected set; }


        public long? CatalogId { get; set; }
        public virtual CatalogEntity Catalog { get; set; }

        public CategoryEntity()
        {
            Children = new List<CategoryEntity>();
        }
    }
}
