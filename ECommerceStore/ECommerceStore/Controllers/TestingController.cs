using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceStore.Controllers
{
    public class TestingController : Controller
    {
        // GET: Testing
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                var files = Request.Files;

                //iterating through multiple file collection   
                foreach (string str in files)
                {
                    HttpPostedFileBase file = Request.Files[str] as HttpPostedFileBase;
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = System.IO.Path.GetFileName(file.FileName);
                        var ServerSavePath = System.IO.Path.Combine(Server.MapPath("~/Uploads/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);

                    }

                }
                return Json("File Uploaded Successfully!");
            }
            else
            {
                return Json("No files to upload");
            }
        }
    }
}