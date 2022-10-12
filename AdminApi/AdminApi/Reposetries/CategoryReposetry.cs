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
                    new SqlParameter("@Action","4"),
            };
            int res = dataAccess.ExecuteNonQueryProc("pro_category", param);
            n = res > 0 ? true : false;
            return n;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> lst = new List<Category>();
            SqlParameter[] param = new SqlParameter[]
           {
                    new SqlParameter("@Action","3")
           };
            DataTable dt = dataAccess.ExecProcDataTable("pro_category", param);
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
                    new SqlParameter("@Action","1"),
            };
            int res = dataAccess.ExecuteNonQueryProc("pro_category", param);
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
                    new SqlParameter("@Action","2"),
            };
            int res = dataAccess.ExecuteNonQueryProc("pro_category", param);
            n = res > 0 ? true : false;
            return n;
        }
    }
}