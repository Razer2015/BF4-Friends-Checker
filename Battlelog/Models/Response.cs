using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battlelog.Models
{
    public class Response<T>
    {
        public string type { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}