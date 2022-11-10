using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SharedModel.Models;

namespace ECommerceStore.Controllers
{
    public class SubCategoryController : Controller
    {

        #region DECLARATION
        string apiurl = ConfigurationManager.AppSettings["AdminApiUrl"].ToString();
        ICommonAPI api = new CommonAPI();
        #endregion
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

        public JsonResult Save(Category category)
        {
            Response responseToView = new Response();
            string saveurl =apiurl+ "Category/Update";
            string updateurl = apiurl+ "Category/SaveSubCategory";
            try
            {
                if (category.id > 0)  
                {
                    category.update_by = 2;
                    category.update_date = DateTime.Now;
                    category.isactive = true;
                    category.isdeleted = false;
                    Response responseResult = api.Post(updateurl, category);
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
                    Response responseResult = api.Post(saveurl, category);
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

        public JsonResult BindSubCategoryList()
        {
            List<Category> lst = new List<Category>();
            string url = apiurl + "Category/GetAllSubCategories";
            try
            {
                Response responseResult = api.Get(url);
                if (responseResult.status)
                {
                    lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
                }

            }
            catch (Exception e) { }

            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BindSubCategoryById(int Id)
        {
            Category obj = new Category();
            string url = apiurl + "Category/Edit?id=" + Id + "";
            try
            {
                Response responseResult = api.Get(url);
                if (responseResult.status)
                {
                    obj = JsonConvert.DeserializeObject<Category>(responseResult.data.ToString());
                }

            }
            catch { }

            return PartialView("Newform", obj);
        }

        public ActionResult DelSubCategoryById(int Id)
        {
            Category obj = new Category();
            string url = apiurl + "Category/Del?id=" + Id + "";
            try
            {
                Response responseResult = api.Get(url);
                if (responseResult.status)
                {
                }

            }
            catch { }

            return PartialView("Newform");
        }
        public ActionResult Initialreturn()
        {
            return PartialView("NewForm");
        }
    }
}