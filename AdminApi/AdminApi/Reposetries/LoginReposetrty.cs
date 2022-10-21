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
    public class LoginReposetrty : ILoginReposetry
    {
        DataAccess dataAccess = new DataAccess();
        Common com = new Common();

        public bool Delete(int id)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",id),
                    new SqlParameter("@Action",LoginAction.delete),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_login, param);
            n = res > 0 ? true : false;
            return n;
        }

        public Login Edit(int id)
        {
            List<Login> lst = new List<Login>();
            Login login = new Login();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",id),
                new SqlParameter("@Action",LoginAction.Edit),
            };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_login, param);
            lst = com.ConvertDataTable<Login>(dt);
            login = lst.FirstOrDefault();
            return login;
        }

        public List<Login> GeltAllLogin()
        {
            List<Login> lst = new List<Login>();
            SqlParameter[] param = new SqlParameter[]
           {
                    new SqlParameter("@Action",LoginAction.GetAllLogin)
           };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_login, param);
            //DataTable to list convertion
            lst = com.ConvertDataTable<Login>(dt);
            return lst;
        }

        public bool SaveLogin(Login login)
        {

            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",login.id),
                    new SqlParameter("@user_id",login.user_id),
                    new SqlParameter("@user_name",login.user_name),
                    new SqlParameter("@email",login.email),
                    new SqlParameter("@password",login.password),
                    new SqlParameter("@mobile",login.mobile),
                    new SqlParameter("@isactive",login.isactive),
                    new SqlParameter("@isdeleted",login.isdeleted),
                    new SqlParameter("@Action",LoginAction.insert),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_login, param);
            n = res > 0 ? true : false;
            return n;
        }

        public bool Update(Login login)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                   new SqlParameter("@id",login.id),
                    new SqlParameter("@user_id",login.user_id),
                    new SqlParameter("@user_name",login.user_name),
                    new SqlParameter("@email",login.email),
                    new SqlParameter("@password",login.password),
                    new SqlParameter("@mobile",login.mobile),
                    new SqlParameter("@isactive",login.isactive),
                    new SqlParameter("@isdeleted",login.isdeleted),
                    new SqlParameter("@Action",LoginAction.Update),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_login, param);
            n = res > 0 ? true : false;
            return n;
        }
    }
}