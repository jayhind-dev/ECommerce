using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerceStore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SharedModel.Models;

namespace ECommerceStore.Controllers
{
    public class ProductController : Controller
    {
        private object category;

        // GET: Product
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
        public JsonResult Save(Product product)
        {
            Response responseToView = new Response();
            try
            {
                product.created_by = 2;
                product.created_date = DateTime.Now;
                product.isactive = true;
                product.isdeleted = false;
                JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                serializerSettings.Converters.Add(new DataTableConverter());
                string jsonString = JsonConvert.SerializeObject(product, Formatting.None, serializerSettings);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Product/SaveProduct");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                { streamWriter.Write(jsonString); streamWriter.Flush(); streamWriter.Close(); }
                string responseText = string.Empty;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
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

        public JsonResult BindProductList()
        {
            List<Product> lst = new List<Product>();
            try
            {
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

            }
            catch (Exception e) { }

            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BindProductById(int Id)
        {
            Product obj = new Product();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Product/Edit?id=" + Id + "");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
                if (responseResult.status)
                {
                    obj = JsonConvert.DeserializeObject<Product>(responseResult.data.ToString());
                }

            }
            catch { }

            return PartialView("Newform", obj);
        }
        public JsonResult BindCategriesbytypeid(int Id)
        {
            List<Category> lst = new List<Category>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Category/GeltAllCategories");
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
            lst = lst.Where(x => x.p_id == Id).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BindSubCategriesbytypeid(int Id)
        {
            List<Category> lst = new List<Category>();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Category/GetAllSubCategories");
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
            lst = lst.Where(x => x.p_id == Id).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        
    }
}