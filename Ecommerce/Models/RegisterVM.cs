using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class RegisterVM
    {
        //[Required]
        public string Email { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
