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
                    response.status = true;
                    response.data = n;
                }
                else
                {
                    response.status = false;
                  
                }
            }
            catch (Exception ex)
            {
                response.status = false;
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
                    response.status = true;
                }
                else
                {
                    response.status =false;
                }
            }
            catch (Exception ex){response.status = false;response.error = ex.Message.ToString();}
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/Category/GetAllTypeCategories")]
        [HttpGet]
        public HttpResponseMessage GetAllTypeCategories()
        {
            Response response = new Response();
            List<Category> _typelist = new List<Category>();
            try
            {
                _typelist = repo.GetAllTypeCategories();
                if (_typelist.Count > 0)
                {
                    response.data = _typelist;
                    response.status = true;
                }
                else
                {
                    response.status =false;
                }
            }
            catch (Exception ex) { response.status =false; response.error = ex.Message.ToString(); }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [Route("api/Category/GetAllSubCategories")]
        [HttpGet]
        public HttpResponseMessage GetAllSubCategories()
        {
            Response response = new Response();
            List<Category> _subcategorylist = new List<Category>();
            try
            {
                _subcategorylist = repo.GetAllSubCategories();
                if(_subcategorylist.Count>0)
                {
                    response.data = _subcategorylist;
                    response.status = true;
                }
                else
                {
                    response.status = false;
                }
            }
            catch (Exception ex) { response.status = false; response.error = ex.Message.ToString(); }
            return Request.CreateResponse(HttpStatusCode.OK, response);
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
                    response.status = true;
                    response.data = n;
                }
                else
                {
                    response.status = false;

                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.error = ex.Message.ToString();
                Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
            return Request.CreateResponse(HttpStatusCode.Accepted, response);
        }

        //sub category 
        [Route("api/Category/SaveSubCategory")]
        [HttpPost]
        public HttpResponseMessage SaveSubCategory(Category category)
        {
            Response response = new Response();
            try
            {
                bool n = repo.SaveCategory(category);
                if (n)
                {
                    response.status = true;
                    response.data = n;
                }
                else
                {
                    response.status = false;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.error = ex.Message.ToString();
                Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
            return Request.CreateResponse(HttpStatusCode.Created, response);
        }


        [Route("api/Category/Edit")]
        [HttpGet]
        public HttpResponseMessage Edit(int id)
        {
            Category category = new Category();
            Response response = new Response();
            try
            {
                category = repo.Edit(id);
                if (category != null)
                {
                    response.data = category;
                    response.status = true;
                }
                else
                {
                    response.status = false;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.error = ex.Message.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.Accepted, response);
        }

        [Route("api/Category/Del")]
        [HttpGet]
        public HttpResponseMessage Del(int id)
        {
            bool n = false;
            Response response = new Response();
            try
            {
                n = repo.Delete(id);
                if (n)
                {
                    response.data = n;
                    response.status = true;
                }
                else
                {
                    response.status = false;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.error = ex.Message.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.Accepted, response);
        }
    
    }
}
