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
    }
    enum CategoryAction
    {
            Insert =1,
            Update=2,
            SelectAllCategory = 3,
            Delete =4,
            SelectAllType=5,
            SelectAllSubCategory=6,

    }
    enum ProductAction
    {
        Insert=1,
        Update=2,
        Delete=3,
        Select=4,
        Edit=5,

    }
}