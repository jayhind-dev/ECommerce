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
    public class AddressController : ApiController
    {
        IAddressReposetry repo = new AddressReposetry();
        [Route("api/Address/SaveAddress")]
        [HttpPost]
        public HttpResponseMessage SaveAddress(Address address)
        {
            Response response = new Response();
            try
            {
                bool n = repo.SaveAddress(address);
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

        [Route("api/Address/GeltAllAddress")]
        [HttpGet]
        public HttpResponseMessage GeltAllAddress()
        {
            Response response = new Response();
            List<Address> address = new List<Address>();
            try
            {
                address = repo.GetAllCategories();
                if (address.Count > 0)
                {
                    response.data = address;
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

        [Route("api/Address/Update")]
        [HttpPost]
        public HttpResponseMessage Update(Address address)
        {
            Response response = new Response();
            try
            {
                bool n = repo.Update(address);
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



        [Route("api/Address/Edit")]
        [HttpGet]
        public HttpResponseMessage Edit(int id)
        {
            Address address = new Address();
            Response response = new Response();
            try
            {
                address = repo.Edit(id);
                if (address != null)
                {
                    response.data = address;
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


        [Route("api/Address/Delete")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
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
