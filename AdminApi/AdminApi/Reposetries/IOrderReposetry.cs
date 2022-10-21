using SharedModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApi.Reposetries
{
    interface IOrderReposetry
    {
        int SaveOrders(Orders orders);
        bool SaveOrderItem(Order_Item item);
        bool UpdateOrderStatus(int id, int status_id);
        List<Orders> GeltAllOrder();
        bool CancelOrder(int id, int iscancel);
    }
}
