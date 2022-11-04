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

namespace ECommerceStore.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult MainView()
        {
            return View();
        }
        public ActionResult Newform()
        {

            Category _obj = new Category();
            return PartialView(_obj);
        }
        public ActionResult List()
        {
            return View();
        }
        public JsonResult Save(Category category)
        {
            Response responseToView = new Response();

            try
            {
                if (category.id > 0)
                {
                    category.update_by = 2;
                    category.update_date = DateTime.Now;
                    category.isactive = true;
                    category.isdeleted = false;
                    JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                    serializerSettings.Converters.Add(new DataTableConverter());
                    string jsonString = JsonConvert.SerializeObject(category, Formatting.None, serializerSettings);
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Category/Update");
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
                else
                {
                    category.created_by = 2;
                    category.created_date = DateTime.Now;
                    category.isactive = true;
                    category.isdeleted = false;
                    JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                    serializerSettings.Converters.Add(new DataTableConverter());
                    string jsonString = JsonConvert.SerializeObject(category, Formatting.None, serializerSettings);
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Category/SaveCategory");
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

            }
            catch (Exception ex)
            {
                responseToView.status = false;
                responseToView.error = "Server Error";
            }

            return Json(responseToView, JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult BindCategoryList()
        {
            List<Category> lst = new List<Category>();
            try
            {
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

            }
            catch { }

            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BindCategoryById(int Id)
        {
            Category obj = new Category();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Category/Edit?id=" + Id + "");
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
                if (responseResult.status)
                {
                    obj = JsonConvert.DeserializeObject<Category>(responseResult.data.ToString());
                }

            }
            catch { }

            return PartialView("Newform", obj);
        }
        public ActionResult DelCategoryById(int Id)
        {
            Category obj = new Category();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Category/Del?id=" + Id + "");
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
                if (responseResult.status)
                {
                }
            }
            catch { }

            return PartialView("Newform");
        }
      

    }
}