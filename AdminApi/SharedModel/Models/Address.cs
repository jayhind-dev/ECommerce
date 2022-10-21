using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Models
{
    public class Address
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string contry { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string comment { get; set; }
        public int created_by { get; set; }
        public int update_by { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? update_date { get; set; }
        public bool? isactive { get; set; }
        public bool? isdeleted { get; set; }
    }
}
