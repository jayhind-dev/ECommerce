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
        #region DECLARATION
        string apiurl = ConfigurationManager.AppSettings["AdminApiUrl"].ToString();
        ICommonAPI api = new CommonAPI();
        #endregion
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
            string url = apiurl + "Banner/SaveBanner";
            try
            {
                
                banner.create_by = 2;
                banner.create_date = DateTime.Now;
                banner.updated_by = 3;
                banner.updated_date= DateTime.Now;
                banner.isactive = true;
                banner.isdeleted = false;
                banner.image = Upload(banner.img);
                banner.img = null;
                Response responseResult = api.Post(url, banner);
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
            string url = apiurl + "Banner/GeltAllBanner";
            try
            {
                Response responseResult = api.Get(url);
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
            string url = apiurl + "Banner/BannerEdit?id=" + Id + "";
            try
            {
                Response responseResult = api.Get(url);
                if (responseResult.status)
                {
                    obj = JsonConvert.DeserializeObject<banner>(responseResult.data.ToString());
                }

            }
            catch { }

            return PartialView("Form_Slider", obj);
        }
    } 
}
