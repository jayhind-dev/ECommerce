using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
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
        #region DECLARATION
        string apiurl = ConfigurationManager.AppSettings["AdminApiUrl"].ToString();
        ICommonAPI api = new CommonAPI();
        #endregion
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
   
        public JsonResult Save(VMProduct product)
        {
            Response responseToView = new Response();
            string updateurl = apiurl + "Product/Update";
            string saveurl = apiurl + "Product/SaveProduct";
            try
            {
                ViewBag.product = product;
            
                if (product.id > 0)
                {
                    

                    Product productapi = new Product();
                    productapi.id = product.id;
                    productapi.group_id = product.group_id;
                    productapi.Pro_Category = product.Pro_Category;
                    productapi.Pro_Type = product.Pro_Type;
                    productapi.Pro_SubCategory = product.Pro_SubCategory;
                    productapi.Category_id = product.Category_id;
                    productapi.attribute_set_id = product.attribute_set_id;
                    productapi.name = product.name;
                    productapi.description = product.description;
                    productapi.tax_id = product.tax_id;
                    productapi.price = product.price;
                    productapi.sku = product.sku;
                    productapi.stock = product.stock;
                    //productapi.Multiimgstring = Upload(product.Multiimg);
                    //productapi.Singleimgstring = Upload(product.Singleimg);
                    productapi.created_by = 2;
                    productapi.created_date = DateTime.Now;
                    productapi.isactive = true;
                    productapi.isdeleted = false;
                    Response responseResult = api.Post(updateurl, product);
                    if (responseResult.status)
                    {
                        responseToView.status = true;
                        responseToView.data = responseResult.data;
                    }
                    else { responseToView.status = false; responseToView.error = responseResult.error; }

                }
                else
                {

                    Product productapi = new Product();
                    productapi.id = product.id;
                    productapi.group_id = product.group_id;
                    productapi.Category_id = product.Category_id;
                    productapi.Pro_Category = product.Pro_Category;
                    productapi.Pro_Type = product.Pro_Type;
                    productapi.Pro_SubCategory = product.Pro_SubCategory;
                    productapi.attribute_set_id = product.attribute_set_id;
                    productapi.name = product.name;
                    productapi.description = product.description;
                    productapi.tax_id = product.tax_id;
                    productapi.price = product.price;
                    productapi.sku = product.sku;
                    productapi.stock = product.stock;
                    productapi.Multiimgstring = Upload(product.Multiimg);
                    productapi.Singleimgstring = Upload(product.Singleimg);
                    productapi.created_by = 2;
                    productapi.created_date = DateTime.Now;
                    productapi.isactive = true;
                    productapi.isdeleted = false;
                  Response responseResult = api.Post(saveurl, product);
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

        public ActionResult BindProductById(int? Id)
        {
            VMProduct obj = new VMProduct();
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
                    obj = JsonConvert.DeserializeObject<VMProduct>(responseResult.data.ToString());
                }

            }
            catch(Exception ex)
            { 
            
            }

            return PartialView("Newform", obj);
        }
        public JsonResult BindCategriesbytypeid(int Id)
        {
            List<Category> lst = new List<Category>();
            string url = apiurl + "Category/GeltAllCategories";
            Response responseResult = api.Get(url);
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
            string url = apiurl + "Category/GetAllSubCategories";
            Response responseResult = api.Get(url);
            if (responseResult.status)
            {
                lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
            }
            lst = lst.Where(x => x.p_id == Id).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public ActionResult img()
        {
            return View();
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
                    string path = Path.Combine(Server.MapPath("~/Content/ProductImage"), fileName);
                    if (string.IsNullOrEmpty(FilePath))
                    {
                        FilePath = "~/Content/ProductImage" + fileName;
                    }
                    else
                    {
                        FilePath = FilePath + "," + "~/Content/ProductImage" + fileName;
                    }
                    file.SaveAs(path); //File will be saved in application root
                }
            }
            catch(Exception ex) { FilePath = null; }
            return FilePath;


        }
        public ActionResult DelProductById(int Id)
        {
            Product obj = new Product();
            string url = apiurl + "Product/Delete?id=" + Id + "";
            try
            {
                Response responseResult = api.Get(url);
                if (responseResult.status)
                {
                }
            }
            catch (Exception ex) { }

            return PartialView("Newform");
        }

        public ActionResult Initialreturn()
        {
            return PartialView("NewForm");
        }


    }
    
}