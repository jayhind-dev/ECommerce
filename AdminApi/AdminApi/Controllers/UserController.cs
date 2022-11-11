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
    public class UserController : ApiController
    {
        IUserReposetries repo = new UserReposetries();
        [Route("api/User/SaveUserDetails")]
        [HttpPost]
        public HttpResponseMessage SaveUserDetails(User user)
        {
            Response response = new Response();
            try
            {
                List<User> userdetails = new List<User>();
                userdetails = repo.SaveUserDetails(user);
                if (user!=null)
                {
                    response.status = true;
                    response.data = user;
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

        [Route("api/User/GeltAllUserDetails")]
        [HttpGet]
        public HttpResponseMessage GeltAllUserDetails()
        {
            Response response = new Response();
            List<User> _userlist = new List<User>();
            try
            {
                _userlist = repo.GeltAllUserDetails();
                if (_userlist.Count > 0)
                {
                    response.data = _userlist;
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

        [Route("api/User/Update")]
        [HttpPost]
        public HttpResponseMessage Update(User user)
        {
            Response response = new Response();
            try
            {
                bool n = repo.Update(user);
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


        [Route("api/User/Edit")]
        [HttpGet]
        public HttpResponseMessage Edit(int user_id)
        {
            User user = new User();
            Response response = new Response();
            try
            {
                user = repo.Edit(user_id);
                if (user != null)
                {
                    response.data = user;
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

        [Route("api/User/Del")]
        [HttpGet]
        public HttpResponseMessage Del(int user_id)
        {
            bool n = false;
            Response response = new Response();
            try
            {
                n = repo.Delete(user_id);
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
