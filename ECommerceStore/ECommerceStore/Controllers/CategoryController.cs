using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharedModel.Models;


namespace ECommerceStore.Controllers
{
    public class CategoryController : Controller
    {
        int i = 2;
        // GET: Category
        public ActionResult Category()
        {
            Category category = new Category();
           
            return View();
        }
       
        [HttpPost]
        public ActionResult SubCategory(Category cat)
        {
            return View();
        }


    }
}