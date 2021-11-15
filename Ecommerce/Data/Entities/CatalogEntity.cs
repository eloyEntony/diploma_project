using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities
{
    public class CatalogEntity : BaseEntity<long>
    {

        [Required, StringLength(255)]
        public string Image { get; set; }
        public virtual ICollection<CategoryEntity> Categories { get; set; }

        public CatalogEntity()
        {
            Categories = new List<CategoryEntity>();
        }

    }
}
