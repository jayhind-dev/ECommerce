using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharedModel.Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using System.Configuration;

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
        [HttpPost]
        public JsonResult Save(banner banner)
        {
            Response responseToView = new Response();
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) =>
                {
                    return true;
                };
                if (banner.id > 0)
                {

                    banner.create_by = 2;
                    banner.create_date = DateTime.Now;
                    banner.updated_by = 3;
                    banner.updated_date = DateTime.Now;
                    banner.isactive = true;
                    banner.isdeleted = false;
                    //banner.image = Upload(banner.img);
                    banner.img = null;
                    JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                    serializerSettings.Converters.Add(new DataTableConverter());
                    string jsonString = JsonConvert.SerializeObject(banner, Formatting.None, serializerSettings);
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Banner/BannerUpdate");
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
                    banner.create_by = 2;
                    banner.create_date = DateTime.Now;
                    banner.updated_by = 3;
                    banner.updated_date = DateTime.Now;
                    banner.isactive = true;
                    banner.isdeleted = false;
                    banner.image = Upload(banner.img);
                    banner.img = null;
                    JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                    serializerSettings.Converters.Add(new DataTableConverter());
                    string jsonString = JsonConvert.SerializeObject(banner, Formatting.None, serializerSettings);
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Banner/SaveBanner");
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
            return Json(responseToView, JsonRequestBehavior.AllowGet);
        
        }
        public string Upload(HttpPostedFileBase[] Files)
        {
            string imgname = "";
            string FilePath = "";
            try
            {
                for (int i = 0; i < Files.Length; i++)
                {
                    HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                                //Use the following properties to get file's name, size and MIMEType
                    int fileSize = file.ContentLength;
                    string fileName = file.FileName;
                    imgname += file.FileName + ",";
                    string mimeType = file.ContentType;
                    System.IO.Stream fileContent = file.InputStream;
                    //To save file, use SaveAs method
                    string path = Path.Combine(Server.MapPath("~/Content/Sliderimage"), fileName);
                    if (string.IsNullOrEmpty(FilePath))
                    {
                        FilePath = "~/Content/Sliderimage" + fileName;
                    }
                    else
                    {
                        FilePath = FilePath + "," + "~/Content/Sliderimage" + fileName;
                    }
                    file.SaveAs(path); //File will be saved in application root
                }
            }
            catch (Exception ex) { FilePath = null; }
            return FilePath;


        }

        public JsonResult BindbannerList()
        {
            List<banner> lst = new List<banner>();
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) =>
                {
                    return true;
                };
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Banner/GeltAllBanner");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
                if (responseResult.status)
                {
                    lst = JsonConvert.DeserializeObject<List<banner>>(responseResult.data.ToString());
                }

            }
            catch (Exception ex) 
            { }

            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult BindBannertById(int Id)
        {
           banner obj = new banner();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Banner/BannerEdit?id=" + Id + "");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
                if (responseResult.status)
                {
                    obj = JsonConvert.DeserializeObject<banner>(responseResult.data.ToString());
                }

            }
            catch { }

            return PartialView("Form_Slider", obj);
        }

        public ActionResult DelBannerById(int Id)
        {
            banner obj = new banner();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Banner/BannerDelete?id=" + Id + "");
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responseText = string.Empty;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
                Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
                if (responseResult.status)
                {
                }
            }
            catch (Exception ex) { }

            return PartialView("Form_Slider");
        }

        public ActionResult Initialreturn()
        {
            return PartialView("Form_Slider");
        }


    }
}
