using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities
{
    public class UserApp: IdentityUser<long>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
