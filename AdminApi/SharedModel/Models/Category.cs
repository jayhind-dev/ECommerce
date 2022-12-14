using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Models
{
    public class Category
    {
        public int id { get; set; }
        public int p_id { get; set; }
        public string Type { get; set; }
        public string type_category { get; set; }
        public string category_name { get; set; }
        public string subcategory_name { get; set; }
        public int created_by { get; set; }
        public int update_by { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? update_date { get; set; }
        public bool? isactive { get; set; }
        public bool? isdeleted { get; set; }
        public int Category_id { get; set; }
    }
}
