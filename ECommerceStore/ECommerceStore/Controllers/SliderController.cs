using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharedModel.Models;

namespace ECommerceStore.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult Main_View()
        {
            return View();
        }
        public ActionResult Form_Slider()
        {
            return View();
        }
        public ActionResult List_Slider()
        {
            return View();
        }

    }
}