using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SharedModel.Models
{
   public class banner
    {
        public int id { get; set; }
        public string image { get; set; }
        public HttpPostedFileBase[] img { get; set; }
        public string content { get; set; }
        public string type { get; set; }
        public int order_type { get; set; }
        public long width { get; set; }
        public long hiegth { get; set; }
        public int create_by { get; set; }
        public int updated_by { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? updated_date { get; set; }
        public bool? isactive { get; set; }
        public bool? isdeleted { get; set; }
    }
}
