using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Models
{
   public class Login
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public double mobile { get; set; }
        public bool? isactive { get; set; }
        public bool? isdeleted { get; set; }
    }
}
