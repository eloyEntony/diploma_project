using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class AttributeSlimVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class AttributeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long GroupId { get; set; } 
        public string Value { get; set; }
    }
}
