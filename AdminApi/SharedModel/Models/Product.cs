using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Models
{
  public class Product
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public int attribute_set_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int tax_id { get; set; }
        public decimal price { get; set; }
        public string sku { get; set; }
        public int stock { get; set; }
        public int created_by { get; set; }
        public int update_by { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? update_date { get; set; }
        public bool? isactive { get; set; }
        public bool? isdeleted { get; set; }

    }
}
