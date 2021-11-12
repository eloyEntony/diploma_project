using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities
{
    public class UserRole : IdentityUserRole<long>
    {
        public virtual UserApp User { get; set; }
        public virtual RoleApp Role { get; set; }
    }
}
