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
    public class BannerController : ApiController
    {
        IBannerReposetry bannerRepo = new BannerReposetry();
        // GET: Banner
        [Route("api/Banner/SaveBanner")]
        [HttpPost]
        public HttpResponseMessage SaveBanner(banner banner)
        {
            Response response = new Response();
            try
            {
                bool n = bannerRepo.SaveBanner(banner);
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

        [Route("api/Banner/GeltAllBanner")]
        [HttpGet]
        public HttpResponseMessage GeltAllBanner()
        {
            Response response = new Response();
            List<banner> _bannerlist = new List<banner>();
            try
            {
                _bannerlist = bannerRepo.GeltAllBanner();
                if (_bannerlist.Count > 0)
                {
                    response.data = _bannerlist;
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

        [Route("api/Banner/BannerEdit")]
        [HttpGet]
        public HttpResponseMessage BannerEdit(int id)
        {
           banner banner = new banner();
            Response response = new Response();
            try
            {
                banner = bannerRepo.BannerEdit(id);
                if (banner != null)
                {
                    response.data = banner;
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

        [Route("api/Banner/BannerUpdate")]
        [HttpPost]
        public HttpResponseMessage BannerUpdate(banner banner)
        {
            Response response = new Response();
            try
            {
                bool n = bannerRepo.BannerUpdate(banner);
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

        [Route("api/Banner/BannerDelete")]
        [HttpGet]
        public HttpResponseMessage BannerDelete(int id)
        {
            bool n = false;
            Response response = new Response();
            try
            {
                n = bannerRepo.BannerDelete(id);
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
