using AdminApi.Helper;
using AdminApi.Models;
using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdminApi.Reposetries
{
    public class OrderReposetry : IOrderReposetry
    {
        DataAccess dataAccess = new DataAccess();
        Common com = new Common();

        public bool CancelOrder(int id, int iscancel)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",id),
                    new SqlParameter("@iscancel",iscancel),
                    new SqlParameter("@Action",orderAction.CancelOrder),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_proOrder, param);
            n = res > 0 ? true : false;
            return n;
        }

        public List<Orders> GeltAllOrder()
        {
            
                List<Orders> lst = new List<Orders>();
                SqlParameter[] param = new SqlParameter[]
               {
                    new SqlParameter("@Action",orderAction.GetOrderDetails)
               };
                DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_proOrder, param);
                //DataTable to list convertion
                lst = com.ConvertDataTable<Orders>(dt);
                return lst;
            
        }

        public bool SaveOrderItem(Order_Item item)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@order_id",item.order_id),
                    new SqlParameter("@product_id",item.product_id),
                    new SqlParameter("@Quntity",item.Quntity),
                    new SqlParameter("@price",item.price),
                    new SqlParameter("@Action",orderAction.ItemInsert),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_proOrder, param);
            n = res > 0 ? true : false;
            return n;
        }

        public int SaveOrders(Orders orders)
        {
            int orderNum = 0;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",orders.id),
                    new SqlParameter("@user_id",orders.user_id),
                    new SqlParameter("@status_id",orders.status_id),
                    new SqlParameter("@carrier_id",orders.carrier_id),
                    new SqlParameter("@shipping_address_id",orders.shipping_address_id),
                    new SqlParameter("@billing_address_id",orders.billing_address_id),
                    new SqlParameter("@currency_id",orders.currency_id),
                    new SqlParameter("@comment",orders.comment),
                    new SqlParameter("@shipping_no",orders.shipping_no),
                    new SqlParameter("@invoice_no",orders.invoice_no),
                    new SqlParameter("@invoice_date",orders.invoice_date),
                    new SqlParameter("@delivery_date",orders.delivery_date),
                    new SqlParameter("@total_discount",orders.total_discount),
                    new SqlParameter("@total_discount_tax",orders.total_discount_tax),
                    new SqlParameter("@total_shipping",orders.total_shipping),
                    new SqlParameter("@total_shipping_tax",orders.total_shipping_tax),
                    new SqlParameter("@total",orders.total),
                    new SqlParameter("@total_tax",orders.total_tax),
                    new SqlParameter("@iscancel",orders.iscancel),
                    new SqlParameter("@isactive",orders.isactive),
                    new SqlParameter("@isdeleted",orders.isdeleted),
                    new SqlParameter("@update_by",orders.update_by),
                    new SqlParameter("@update_date",orders.update_date),
                    new SqlParameter("@created_by",orders.created_by),
                    new SqlParameter("@created_date",orders.created_date),
                    new SqlParameter("@Action",orderAction.Insert),
            };
             orderNum = dataAccess.ExecProcGetint(SPKeys.p_proOrder, param);
            return orderNum;
        }

        public bool UpdateOrderStatus(int id, int status_id)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",id),
                    new SqlParameter("@status_id",status_id),
                    new SqlParameter("@Action",orderAction.OrderStatusUpadte),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_proOrder, param);
            n = res > 0 ? true : false;
            return n;
        }
    }
}