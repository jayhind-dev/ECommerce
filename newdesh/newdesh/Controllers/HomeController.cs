using ECommerceStore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace newdesh.Controllers
{
    public class HomeController : Controller
    {
        #region DECLARATION
        string apiurl = ConfigurationManager.AppSettings["AdminApiUrl"].ToString();
        ICommonAPI api = new CommonAPI();
        #endregion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Product(string subcategory_id)
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Signin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public List<SelectListItem> GetTypeDDl()
        {
            // Api for List

            List<Category> lst = new List<Category>();
            try
            {
                Response responseResult = api.Get(apiurl + "/Category/GetAllTypeCategories");      
                  
                if (responseResult.status)
                {
                    lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
                }

            }
            catch { }

            //Selected Single Text and Id For DropDown

            List<SelectListItem> item = lst.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.category_name,
                    Value = a.id.ToString(),
                    Selected = false
                };
            });
            return item;
        }

        public JsonResult BindAllDepartments()
        {
            return Json(GetTypeDDl(), JsonRequestBehavior.AllowGet);
        }


        public List<SelectListItem> GetCategoryDDl()
        {
            // Api for List

            List<Category> lst = new List<Category>();
            try
            {
                Response responseResult = api.Get(apiurl + "/Category/GeltAllCategories");
                if (responseResult.status)
                {
                    lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
                }

            }
            catch { }

            //Selected Single Text and Id For DropDown

            List<SelectListItem> item = lst.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.category_name,
                    Value = a.id.ToString(),
                    Selected = false
                };
            });
            return item;
        }


        public JsonResult BindAllCategory()
        {
            return Json(GetCategoryDDl(), JsonRequestBehavior.AllowGet);
        }
        public List<SelectListItem> GetSubCategoryDDl()
        {
            List<Category> lst = new List<Category>();
            try
            {
                Response responseResult = api.Get(apiurl + "/Category/GetAllSubCategories");
                if (responseResult.status)
                {
                    lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
                }
            }
            catch (Exception ex)
            {
            
            }
            //Selected Single Text and Id For DropDown
            List<SelectListItem> item = lst.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.category_name,
                    Value = a.id.ToString(),
                    Selected = false
                };
            });
            return item;
        }

       
        public JsonResult BindAllSubCategory()
        {
            return Json(GetSubCategoryDDl(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SignUpData(User user)
        {
            Response responseToView = new Response();
            try
            {
                string url = apiurl + "/User/SaveUserDetails";
                Response responseResult = api.Post(url, user);
                    if (responseResult.status)
                    {
                        responseToView.status = true;
                        responseToView.data = responseResult.data;
                    }
                    else { responseToView.status = false; responseToView.error = responseResult.error; }
            }
            catch (Exception ex)
            {
                responseToView.status = false;
                responseToView.error = "Server Error";
            }
            return Json(responseToView, JsonRequestBehavior.AllowGet); ;
        }
        [HttpPost]
        public JsonResult AddToCart(string Id)
        {
            string nam = "sunil" + Id;

            return Json(nam, JsonRequestBehavior.AllowGet);
        }

    }
}







