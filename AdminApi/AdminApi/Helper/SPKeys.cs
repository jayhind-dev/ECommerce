using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApi.Helper
{
    public static class SPKeys
    {
        public const  string p_category= "pro_category";
        public const string p_products = "pro_products";
        public const string p_productsImage = "pro_ProductImages";
        public const string p_proOrder = "pro_Orders";
        public const string p_userInfo = "pro_User";
        public const string p_login = "pro_Login";
        public const string p_Address = "pro_Address";
        public const string p_Banner = "pro_banner";
    }
    enum CategoryAction
    {
            Insert =1,
            Update=2,
            SelectAllCategory = 3,
            Delete =4,
            SelectAllType=5,
            SelectAllSubCategory=6,
            Edit=7,

    }
    enum ProductAction
    {
        Insert=1,
        Update=2,
        Delete=3,
        Select=4,
        Edit=5,
        SeletecTop=6,

    }
    enum ProductImageAction
    {
        Insert=1,
        SelectProductImage=2,
        Update=3,
        Edit=4,
        Delete=5,
    }
    enum orderAction
    {
        Insert=1,
            ItemInsert=2,
            OrderStatusUpadte=3,
            GetOrderDetails=4,
            CancelOrder=5,
    }

    enum UserAction
    {
        insert = 1,
        GetAllUserDetails = 2,
        update = 3,
        delete = 4,
        edit = 5
    }
    enum LoginAction
    {
        insert = 1,
       GetAllLogin=2,
       Update=3,
       Edit=4,
       delete=5,
    }
    enum AddressAction
    {
        insert=1,
            getAllAddress=2,
            update=3,
            Edit=4,
            delete=5,
    }
    enum BannerAction
    {
        insert = 1,
        getAllbanner = 2,
        update = 3,
        Edit = 4,
        delete = 5,
    }
}