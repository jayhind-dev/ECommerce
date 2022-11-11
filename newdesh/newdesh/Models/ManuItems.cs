using Newtonsoft.Json;
using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace newdesh.Models
{
    public class ManuItems
    {
        public List<Category> GetMenuType()
        {
            List<Category> lst = new List<Category>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44368/api/Category/GetAllTypeCategories");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string responseText = string.Empty;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
            Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
            if (responseResult.status)
            {
                lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
            }
            return lst;
        }

        public List<Category> GetMenuCategory(int typeid)
        {
            List<Category> lst = new List<Category>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44368/api/Category/GeltAllCategories");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string responseText = string.Empty;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
            Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
            if (responseResult.status)
            {
                lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
                lst = lst.Where(l => l.p_id == typeid).ToList();
            }
            return lst;
        }
        public List<Category> GetMenuSubCategory(int catId)
        {
            List<Category> lst = new List<Category>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44368/api/Category/GetAllSubCategories");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string responseText = string.Empty;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { responseText = streamReader.ReadToEnd(); }
            Response responseResult = JsonConvert.DeserializeObject<Response>(responseText);
            if (responseResult.status)
            {
                lst = JsonConvert.DeserializeObject<List<Category>>(responseResult.data.ToString());
                lst = lst.Where(l => l.p_id == catId).ToList();
            }
            return lst;
        }

        //product

        public List<Category> GetProductCategory()
        {
            List<Category> lst = new List<Category>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44368/api/Category/GeltAllCategories");
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
            return lst;
        }

        public List<Product> GetProductsDetails()
        {
            List<Product> lst = new List<Product>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44368/api/Product/GetProducts");
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
            return lst;
        }

    }
}