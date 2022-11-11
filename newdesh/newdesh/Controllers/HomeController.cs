using ECommerceStore.Models;
using newdesh.Models;
using Newtonsoft.Json;
using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace newdesh.Controllers
{
    public class HomeController : Controller
    {
        #region DECLARATION
        string apiurl = "https://localhost:44368/api";
        ICommonAPI api = new CommonAPI();
        #endregion
        public ActionResult Index()
        {
            GeneretOTP generetOTP = new GeneretOTP();
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
                Random rand = new Random();
                int OTP = rand.Next(1000, 9999);
                Session["OTP"] = OTP;
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

        [HttpPost]
        public ActionResult GetAllProductbySubCat_id(string Id)
        {
            List<Product> lst = new List<Product>();
            try {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) =>
                {
                    return true;
                };
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Product/GetAllProducts");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
                if (responseResult.status)
                {
                    lst = JsonConvert.DeserializeObject<List<Product>>(responseResult.data.ToString());
                }
                
            lst = lst.Where(x => x.Pro_SubCategory == Int64.Parse(Id)).ToList();
            }

            catch (Exception ex)
            { }
            return PartialView("Product_Partial", lst);
        }
        public ActionResult Product_Partial()
        {
            return View();
        }



    }
}







