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
    public class UserReposetries : IUserReposetries
    {

        DataAccess dataAccess = new DataAccess();
        Common com = new Common();

        public bool Delete(int user_id)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@user_id",user_id),
                    new SqlParameter("@Action",UserAction.delete),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_userInfo, param);
            n = res > 0 ? true : false;
            return n;
        }

        public User Edit(int user_id)
        {
            List<User> lst = new List<User>();
            User user = new User();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@user_id",user_id),
                new SqlParameter("@Action",UserAction.edit),
            };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_userInfo, param);
            lst = com.ConvertDataTable<User>(dt);
            user = lst.FirstOrDefault();
            return user;
        }

        public List<User> GeltAllUserDetails()
        {
            List<User> lst = new List<User>();
            SqlParameter[] param = new SqlParameter[]
           {
                    new SqlParameter("@Action",UserAction.GetAllUserDetails)
           };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_userInfo, param);
            //DataTable to list convertion
            lst = com.ConvertDataTable<User>(dt);
            return lst;
        }

        public bool SaveUserDetails(User user)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@user_id",user.user_id),
                    new SqlParameter("@name",user.name),
                    new SqlParameter("@last_name",user.last_name),
                    new SqlParameter("@email",user.email),
                    new SqlParameter("@password",user.password),
                    new SqlParameter("@mobile",user.mobile),
                    new SqlParameter("@dob",user.dob),
                    new SqlParameter("@gender",user.gender),
                    new SqlParameter("@remember_token",user.remember_token),
                    new SqlParameter("@isactive",user.isactive),
                    new SqlParameter("@isdeleted",user.isdeleted),
                    new SqlParameter("@update_by",user.update_by),
                    new SqlParameter("@update_date",user.update_date),
                    new SqlParameter("@created_by",user.created_by),
                    new SqlParameter("@created_date",user.created_date),
                    new SqlParameter("@Action",UserAction.insert),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_userInfo, param);
            n = res > 0 ? true : false;
            return n;
        }

        public bool Update(User user)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@user_id",user.user_id),
                    new SqlParameter("@name",user.name),
                    new SqlParameter("@last_name",user.last_name),
                    new SqlParameter("@email",user.email),
                    new SqlParameter("@password",user.password),
                    new SqlParameter("@mobile",user.mobile),
                    new SqlParameter("@dob",user.dob),
                    new SqlParameter("@gender",user.gender),
                    new SqlParameter("@remember_token",user.remember_token),
                    new SqlParameter("@isactive",user.isactive),
                    new SqlParameter("@isdeleted",user.isdeleted),
                    new SqlParameter("@update_by",user.update_by),
                    new SqlParameter("@update_date",user.update_date),
                    new SqlParameter("@Action",UserAction.update),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_userInfo, param);
            n = res > 0 ? true : false;
            return n;
        }
    }
}