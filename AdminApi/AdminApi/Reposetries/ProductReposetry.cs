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
    public class ProductReposetry : IProductReposetry
    {
        DataAccess dataAccess = new DataAccess();
        Common com = new Common();

        public bool Delete(int id)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",id),
                    new SqlParameter("@Action",ProductAction.Delete),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_products, param);
            n = res > 0 ? true : false;
            return n;
        }

        public Product Edit(int id)
        {
            List<Product> _list = new List<Product>();
            Product product = new Product();
            SqlParameter[] param = new SqlParameter[]
                     {
                    new SqlParameter("@id",id),
                    new SqlParameter("@Action",ProductAction.Edit)
                     };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_products, param);
            //DataTable to list convertion
             _list = com.ConvertDataTable<Product>(dt);
            product = _list.FirstOrDefault();

           
            return product;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> _list = new List<Product>();
            SqlParameter[] param = new SqlParameter[]
                     {
                    new SqlParameter("@Action",ProductAction.Select)
                     };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_products, param);
            //DataTable to list convertion
            _list = com.ConvertDataTable<Product>(dt);
            return _list;
        }

        public List<Product> GetProducts()
        {
            List<Product> _list = new List<Product>();
            SqlParameter[] param = new SqlParameter[]
                     {
                    new SqlParameter("@Action",ProductAction.SeletecTop)
                     };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_products, param);
            //DataTable to list convertion
            _list = com.ConvertDataTable<Product>(dt);
            return _list;
        }

        public bool SaveProduct(Product product)
        {
            String[] ImgArr= product.Multiimgstring.Split(',');
            DataTable dt = new DataTable();
            dt.Columns.Add("image_name");
            if(ImgArr!=null&&ImgArr.Length>0)
            {
                foreach(var img in ImgArr)
                {
                    dt.Rows.Add(img);
                }
            }
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@name",product.name),
                new SqlParameter("@group_id",product.group_id),
                new SqlParameter("@description",product.description),
                new SqlParameter("@attribute_set_id",product.attribute_set_id),
                new SqlParameter("@Pro_Type",product.Pro_Type),
                new SqlParameter("@Pro_Category",product.Pro_Category),
                new SqlParameter("@Pro_SubCategory",product.Pro_SubCategory),
                new SqlParameter("@price",product.price),
                new SqlParameter("@sku",product.sku),
                new SqlParameter("@stock",product.stock),
                new SqlParameter("@tax_id",product.tax_id),
                new SqlParameter("@isactive",product.isactive),
                new SqlParameter("@isdeleted",product.isdeleted),
                new SqlParameter("@created_by",product.created_by),
                new SqlParameter("@created_date",product.created_date),
                new SqlParameter("@update_by",product.update_by),
                new SqlParameter("@SingleIMage",product.Singleimgstring),
                new SqlParameter("@MultiImgae",dt),
                new SqlParameter("@Action",ProductAction.Insert),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_products, param);
            n = res > 0 ? true : false;
            return n;
        }

        public bool Update(Product product)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",product.id),
                new SqlParameter("@name",product.name),
                new SqlParameter("@group_id",product.group_id),
                new SqlParameter("@description",product.description),
                new SqlParameter("@attribute_set_id",product.attribute_set_id),
                new SqlParameter("@price",product.price),
                new SqlParameter("@sku",product.sku),
                new SqlParameter("@stock",product.stock),
                new SqlParameter("@tax_id",product.tax_id),
                new SqlParameter("@isactive",product.isactive),
                new SqlParameter("@isdeleted",product.isdeleted),
                new SqlParameter("@created_by",product.created_by),
                new SqlParameter("@created_date",product.created_date),
                new SqlParameter("@update_by",product.update_by),
                new SqlParameter("@update_date",product.update_date),
                new SqlParameter("@Action",ProductAction.Update),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_products, param);
            n = res > 0 ? true : false;
            return n;
        }
    }
}