using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Models
{
    public class OrderStatus_Journey
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int status_id { get; set; }
        public int user_id { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
    }
}
