using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceStore.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult SubCategory()
        {
            return View();
        }
    }
}