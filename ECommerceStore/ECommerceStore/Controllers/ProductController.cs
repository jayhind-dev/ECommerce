﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult MainView()
        {
            return View();
        }
    }
}