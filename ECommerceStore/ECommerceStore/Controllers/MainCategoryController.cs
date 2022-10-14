using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceStore.Controllers
{
    public class MainCategoryController : Controller
    {
        // GET: MainCategory
        public ActionResult MainView()
        {
            return View();
        }
        public ActionResult NewForm()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
    }
}