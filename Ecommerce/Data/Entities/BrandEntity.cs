using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities
{
    public class BrandEntity : BaseEntity<long>
    {
        public string Description { get; set; }

        public bool IsPublished { get; set; }

    }
}
