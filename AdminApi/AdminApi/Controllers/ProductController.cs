using AdminApi.Models;
using AdminApi.Reposetries;
using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminApi.Controllers
{
    public class ProductController : ApiController
    {
        IProductReposetry ProdRepo = new ProductReposetry();
        Product product = new Product();
        // GET: Products

        [Route("api/Product/SaveProduct")]
        [HttpPost]
        public HttpResponseMessage SaveProduct(Product product)
        {
            Response response = new Response();
            try
            {
                bool n = ProdRepo.SaveProduct(product);
                if (n)
                {
                    response.status = "Data Saved";
                    response.data = n;
                }
                else
                {
                    response.status = "Server Error";
                }
            }
            catch (Exception ex)
            {
                response.status = "Server Error";
                response.error = ex.Message.ToString();
            }

            return Request.CreateResponse(HttpStatusCode.Created, response);
        }

        [Route("api/Product/GetAllProducts")]
        [HttpGet]
        public HttpResponseMessage GetAllProducts()
        {
            Response response = new Response();
            List<Product> _prolist = new List<Product>();
            try
            {
                _prolist = ProdRepo.GetAllProducts();
                if (_prolist.Count > 0)
                {
                    response.data = _prolist;
                    response.status = "ok";
                }
                else
                {
                    response.status = "No Record Found";
                }
            }
            catch (Exception ex) { response.status = "Server Erorr"; response.error = ex.Message.ToString(); }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/Product/Delete")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            Response response = new Response();
            try
            {
                bool n = ProdRepo.Delete(id);
                if (n)
                {
                    response.status = "Data Deleted";
                    response.data = n;
                }
                else
                {
                    response.status = "Server Error";

                }
            }
            catch (Exception ex)
            {
                response.status = "Server Error";
                response.error = ex.Message.ToString();
                Request.CreateResponse(HttpStatusCode.NoContent, response);
            }
            return Request.CreateResponse(HttpStatusCode.Accepted, response);
        }

        [Route("api/Product/Edit")]
        [HttpGet]
        public HttpResponseMessage Edit(int id)
        {
            Product product = new Product(); 
            Response response = new Response();
            try
            {
                product = ProdRepo.Edit(id);
                if (product != null)
                {
                    response.data = product;
                    response.status = "ok";
                }
                else
                {
                    response.status = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                response.status = "Server Error";
                response.error = ex.Message.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.Accepted, response);
        }

        [Route("api/Product/Update")]
        [HttpPost]
        public HttpResponseMessage Update(Product product)
        {
            Response response = new Response();
            try
            {
                bool n = ProdRepo.Update(product);
                if (n)
                {
                    response.status = "Data Updated";
                    response.data = n;
                }
                else
                {
                    response.status = "Server Error";

                }
            }
            catch (Exception ex)
            {
                response.status = "Server Error";
                response.error = ex.Message.ToString();
                Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
            return Request.CreateResponse(HttpStatusCode.Created, response);
        }
    }
}
