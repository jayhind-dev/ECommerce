using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SharedModel.Models;

namespace ECommerceStore.Controllers
{
    public class SubCategoryController : Controller
    {
       

        public ActionResult MainView()
        {
            return View();
        }
        public ActionResult Newform()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }

        public JsonResult BindCategoryDDl()
        {
            List<Category> lst = new List<Category>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            try
            {
                string apiUrl = "https://localhost:44368/api/";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl + "Category/GeltAllCategories");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
                if (responseResult.status)
                {
                   lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
                }
               
            }
            catch {  }
        
            return Json(lst,JsonRequestBehavior.AllowGet); 
        }


        public JsonResult BindSubCategories()
        {
            List<Category> lst = new List<Category>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            try
            {
                string apiUrl = "https://localhost:44368/api/";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl + "Category/GeltAllCategories");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
                if (responseResult.status)
                {
                    lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
                }

            }
            catch { }

            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}