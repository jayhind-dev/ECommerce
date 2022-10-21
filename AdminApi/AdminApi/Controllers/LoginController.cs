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
    public class LoginController : ApiController
    {
        ILoginReposetry repo = new LoginReposetrty();
        [Route("api/Login/SaveLogin")]
        [HttpPost]
        public HttpResponseMessage SaveLogin(Login login)
        {
            Response response = new Response();
            try
            {
                bool n = repo.SaveLogin(login);
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

        [Route("api/Login/GeltAllLogin")]
        [HttpGet]
        public HttpResponseMessage GeltAllLogin()
        {
            Response response = new Response();
            List<Login> _list = new List<Login>();
            try
            {
                _list = repo.GeltAllLogin();
                if (_list.Count > 0)
                {
                    response.data = _list;
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

        [Route("api/Login/Update")]
        [HttpPost]
        public HttpResponseMessage Update(Login login)
        {
            Response response = new Response();
            try
            {
                bool n = repo.Update(login);
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


        [Route("api/Login/Edit")]
        [HttpGet]
        public HttpResponseMessage Edit(int id)
        {
            Login login = new Login();
            Response response = new Response();
            try
            {
                login = repo.Edit(id);
                if (login != null)
                {
                    response.data = login;
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

        [Route("api/Login/Delet")]
        [HttpGet]
        public HttpResponseMessage Delet(int id)
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
