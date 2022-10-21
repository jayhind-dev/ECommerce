using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Models
{
    public class User
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public double mobile { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }
        public string remember_token { get; set; }
        public int created_by { get; set; }
        public int update_by { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? update_date { get; set; }
        public bool? isactive { get; set; }
        public bool? isdeleted { get; set; }
    }
}
