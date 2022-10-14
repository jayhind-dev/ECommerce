using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Models
{
    public class Response
    {
        public string status { get; set; }
        public object data { get; set; }
        public string error { get; set; }
    }
}