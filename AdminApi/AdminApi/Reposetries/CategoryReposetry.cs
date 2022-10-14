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
    public class CategoryReposetry : ICategoryReposetry
    {
        DataAccess dataAccess = new DataAccess();
        Common com = new Common();

        public bool Delete(int id)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",id),
                    new SqlParameter("@Action",CategoryAction.Delete),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_category, param);
            n = res > 0 ? true : false;
            return n;
        }

        public Category Edit(int id)
        {
            List<Category> lst = new List<Category>();
            Category category = new Category();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",id),
                new SqlParameter("@Action",CategoryAction.Edit),
            };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_category, param);
            lst = com.ConvertDataTable<Category>(dt);
            category = lst.FirstOrDefault();
            return category;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> lst = new List<Category>();
            SqlParameter[] param = new SqlParameter[]
           {
                    new SqlParameter("@Action",CategoryAction.SelectAllCategory)
           };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_category, param);
            //DataTable to list convertion
            lst = com.ConvertDataTable<Category>(dt);
            return lst;
        }

        public List<Category> GetAllSubCategories()
        {
            List<Category> lst = new List<Category>();
            SqlParameter[] param = new SqlParameter[]
           {
                    new SqlParameter("@Action",CategoryAction.SelectAllSubCategory)
           };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_category, param);
            //DataTable to list convertion
            lst = com.ConvertDataTable<Category>(dt);
            return lst;
        }

        public List<Category> GetAllTypeCategories()
        {
            List<Category> lst = new List<Category>();
            SqlParameter[] param = new SqlParameter[]
           {
                    new SqlParameter("@Action",CategoryAction.SelectAllType)
           };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_category, param);
            //DataTable to list convertion
            lst = com.ConvertDataTable<Category>(dt);
            return lst;
        }

        public bool SaveCategory(Category category)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",category.id),
                    new SqlParameter("@category_name",category.category_name),
                    new SqlParameter("@p_id",category.p_id),
                    new SqlParameter("@isactive",category.isactive),
                    new SqlParameter("@isdeleted",category.isdeleted),
                    new SqlParameter("@update_by",category.update_by),
                    new SqlParameter("@update_date",category.update_date),
                    new SqlParameter("@created_by",category.created_by),
                    new SqlParameter("@created_date",category.created_date),
                    new SqlParameter("@Action",CategoryAction.Insert),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_category, param);
            n=res > 0 ? true : false;
            return n;
        }
        public bool Update(Category category)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",category.id),
                    new SqlParameter("@category_name",category.category_name),
                    new SqlParameter("@p_id",category.p_id),
                    new SqlParameter("@isactive",category.isactive),
                    new SqlParameter("@isdeleted",category.isdeleted),
                    new SqlParameter("@update_by",category.update_by),
                    new SqlParameter("@update_date",category.update_date),
                    new SqlParameter("@created_by",category.created_by),
                    new SqlParameter("@created_date",category.created_date),
                    new SqlParameter("@Action",CategoryAction.Update),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_category, param);
            n = res > 0 ? true : false;
            return n;
        }

    }
}