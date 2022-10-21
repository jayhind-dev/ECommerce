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
    public class OrderController : ApiController
    {
        IOrderReposetry repo = new OrderReposetry();
        [Route("api/Order/SaveOrders")]
        [HttpPost]
        public HttpResponseMessage SaveOrders(Orders orders)
        {
            Response response = new Response();
            try
            {
                int n = repo.SaveOrders(orders);
                if(n>0)
                {
                    foreach(Order_Item item in orders.order_Items)
                    {
                        item.order_id = n;
                      bool res= repo.SaveOrderItem(item);
                        if (res)
                        {
                            response.status = true;
                            response.data = n;
                        }
                        else
                        {
                            response.status = false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.error = ex.Message.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.Created, response);
        }
        [Route("api/Order/UpdateOrderStatus")]
        [HttpPost]
        public HttpResponseMessage UpdateOrderStatus(int id,int status_id)
        {
            Response response = new Response();
            try
            {
                bool n = repo.UpdateOrderStatus(id,status_id);
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


        [Route("api/Order/GeltAllOrder")]
        [HttpGet]
        public HttpResponseMessage GeltAllOrder()
        {
            Response response = new Response();
            List<Orders> _ordersdetails = new List<Orders>();
            try
            {
                _ordersdetails = repo.GeltAllOrder();
                if (_ordersdetails.Count > 0)
                {
                    response.data = _ordersdetails;
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

        [Route("api/Order/CancelOrder")]
        [HttpPost]
        public HttpResponseMessage CancelOrder(int id, int iscancel)
        {
            Response response = new Response();
            try
            {
                bool n = repo.CancelOrder(id, iscancel);
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



    }
}
