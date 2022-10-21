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
    public class ProductImageReposetry : IProductImageReposetry
    {
        DataAccess dataAccess = new DataAccess();
        Common com = new Common();

        public bool Delete(int id)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",id),
                    new SqlParameter("@Action",ProductImageAction.Delete),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_productsImage, param);
            n = res > 0 ? true : false;
            return n;
        }

        public ProductImage Edit(int id)
        {
            List<ProductImage> lst = new List<ProductImage>();
            ProductImage category = new ProductImage();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",id),
                new SqlParameter("@Action",ProductImageAction.Edit),
            };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_productsImage, param);
            lst = com.ConvertDataTable<ProductImage>(dt);
            category = lst.FirstOrDefault();
            return category;
        }

        public List<ProductImage> GeltAllProductImage()
        {
            List<ProductImage> lst = new List<ProductImage>();
            SqlParameter[] param = new SqlParameter[]
           {
                    new SqlParameter("@Action",ProductImageAction.SelectProductImage)
           };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_productsImage, param);
            //DataTable to list convertion
            lst = com.ConvertDataTable<ProductImage>(dt);
            return lst;
        }

        public bool SaveProductImage(ProductImage productImage)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",productImage.id),
                    new SqlParameter("@name",productImage.name),
                    new SqlParameter("@product_id",productImage.product_id),
                    new SqlParameter("@order_val",productImage.order_val),
                    new SqlParameter("@isactive",productImage.isactive),
                    new SqlParameter("@isdeleted",productImage.isdeleted),
                    new SqlParameter("@update_by",productImage.update_by),
                    new SqlParameter("@update_date",productImage.update_date),
                    new SqlParameter("@created_by",productImage.created_by),
                    new SqlParameter("@created_date",productImage.created_date),
                    new SqlParameter("@Action",ProductImageAction.Insert),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_productsImage, param);
            n = res > 0 ? true : false;
            return n;
        }

        public bool Update(ProductImage productImage)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                   new SqlParameter("@id",productImage.id),
                    new SqlParameter("@name",productImage.name),
                    new SqlParameter("@product_id",productImage.product_id),
                    new SqlParameter("@order_val",productImage.order_val),
                    new SqlParameter("@isactive",productImage.isactive),
                    new SqlParameter("@isdeleted",productImage.isdeleted),
                    new SqlParameter("@update_by",productImage.update_by),
                    new SqlParameter("@update_date",productImage.update_date),
                    new SqlParameter("@created_by",productImage.created_by),
                    new SqlParameter("@created_date",productImage.created_date),
                    new SqlParameter("@Action",ProductImageAction.Update),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_productsImage, param);
            n = res > 0 ? true : false;
            return n;
        }
    }
}