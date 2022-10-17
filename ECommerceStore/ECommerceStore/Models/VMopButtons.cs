using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceStore.Models
{
    public class VMopButtons
    {
        public bool EditOn { get; set; }
        public int EditOnId { get; set; }
        public string Controllername { get; set; }
        public string Action { get; set; }
    }
}