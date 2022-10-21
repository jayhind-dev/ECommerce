using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Models
{
   public class Orders
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int status_id { get; set; }
        public int carrier_id { get; set; }
        public int shipping_address_id { get; set; }
        public int billing_address_id { get; set; }
        public int currency_id { get; set; }
        public string comment { get; set; }
        public string shipping_no { get; set; }
        public string invoice_no { get; set; }
        public DateTime invoice_date { get; set; }
        public DateTime delivery_date { get; set; }
        public decimal total_discount { get; set; }
        public decimal total_discount_tax { get; set; }
        public decimal total_shipping { get; set; }
        public decimal total_shipping_tax { get; set; }
        public decimal total { get; set; }
        public decimal total_tax { get; set; }
        public bool? iscancel { get; set; }
        public int created_by { get; set; }
        public int update_by { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? update_date { get; set; }
        public bool? isactive { get; set; }
        public bool? isdeleted { get; set; }
        public List<Order_Item> order_Items { get; set; }
    }
}
