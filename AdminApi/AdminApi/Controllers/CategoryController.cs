using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdminApi.Models;
using AdminApi.Reposetries;
using SharedModel.Models;

namespace AdminApi.Controllers
{
    public class CategoryController : ApiController
    {
        ICategoryReposetry repo = new CategoryReposetry();
        [Route("api/Category/SaveCategory")]
        [HttpPost]
        public HttpResponseMessage SaveCategory(Category category)
        {
            Response response = new Response();
            try
            {
                bool n = repo.SaveCategory(category);
                if(n)
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
                Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
            return Request.CreateResponse(HttpStatusCode.Created, response);
        }

        [Route("api/Category/GeltAllCategories")]
        [HttpGet]
        public HttpResponseMessage GeltAllCategories()
        {
            Response response = new Response();
            List<Category> _categorylist = new List<Category>();
            try
            {
                _categorylist = repo.GetAllCategories();
                if(_categorylist.Count>0)
                {
                    response.data = _categorylist;
                    response.status = "ok";
                }
                else
                {
                    response.status = "No Record Found";
                }
            }
            catch (Exception ex){response.status = "Server Erorr";response.error = ex.Message.ToString();}
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [Route("api/Category/Delete")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            Response response = new Response();
            try
            {
                bool n = repo.Delete(id);
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
        [Route("api/Category/Update")]
        [HttpPost]
        public HttpResponseMessage Update(Category category) 
        { 
            Response response = new Response();
            try
            {
                bool n = repo.Update(category);
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
            return Request.CreateResponse(HttpStatusCode.Accepted, response);
        }
    }
}
