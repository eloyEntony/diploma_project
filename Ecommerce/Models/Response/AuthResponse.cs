using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Response
{
    public class AuthResponse
    {
        public string Token { get; set; }

        public AuthResponse(string token) => (Token) = (token);
    }
}
