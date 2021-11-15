using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Response
{
    public class ResultResponse
    {
        //public T Data { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
