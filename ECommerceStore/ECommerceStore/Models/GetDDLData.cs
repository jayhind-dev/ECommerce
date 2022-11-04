using Newtonsoft.Json;
using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ECommerceStore.Models
{
    public class GetDDLData
    {
        public List<SelectListItem> GetTypeDDl()
        {
            // Api for List

            List<Category> lst = new List<Category>();
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) =>
                {
                    return true;
                };
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["AdminApiUrl"].ToString() + "Category/GetAllTypeCategories");
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
        
              public List<SelectListItem> GetCategoryDDl()
            {
            // Api for List

            List<Category> lst = new List<Category>();
            try
            {
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

        public List<SelectListItem> GetSubCategoryDDl()
        {
            // Api for List

            List<Category> lst = new List<Category>();
            try
            {
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

    }
}