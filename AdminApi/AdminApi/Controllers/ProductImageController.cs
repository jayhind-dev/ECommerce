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
    public class ProductImageController : ApiController
    {
        IProductImageReposetry repo = new ProductImageReposetry();
        [Route("api/ProductImage/SaveProductImage")]
        [HttpPost]
        public HttpResponseMessage SaveProductImage(ProductImage productImage)
        {
            Response response = new Response();
            try
            {
                bool n = repo.SaveProductImage(productImage);
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
            }
            return Request.CreateResponse(HttpStatusCode.Created, response);
        }


        [Route("api/ProductImage/GeltAllProductImage")]
        [HttpGet]
        public HttpResponseMessage GeltAllProductImage()
        {
            Response response = new Response();
            List<ProductImage> _proImagelist = new List<ProductImage>();
            try
            {
                _proImagelist = repo.GeltAllProductImage();
                if (_proImagelist.Count > 0)
                {
                    response.data = _proImagelist;
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

        [Route("api/ProductImage/Edit")]
        [HttpGet]
        public HttpResponseMessage Edit(int id)
        {
            ProductImage productImage = new ProductImage();
            Response response = new Response();
            try
            {
                productImage = repo.Edit(id);
                if (productImage != null)
                {
                    response.data = productImage;
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
