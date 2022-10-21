using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Models
{
    public class Order_Item
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int Quntity { get; set; }
        public decimal price { get; set; }
    }
}
