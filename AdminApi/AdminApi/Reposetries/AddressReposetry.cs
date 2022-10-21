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
    public class AddressReposetry : IAddressReposetry
    {
        DataAccess dataAccess = new DataAccess();
        Common com = new Common();

        public bool Delete(int id)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",id),
                    new SqlParameter("@Action",AddressAction.delete),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_Address, param);
            n = res > 0 ? true : false;
            return n;
        }

        public Address Edit(int id)
        {
            List<Address> lst = new List<Address>();
            Address address = new Address();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",id),
                new SqlParameter("@Action",AddressAction.Edit),
            };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_Address, param);
            lst = com.ConvertDataTable<Address>(dt);
            address = lst.FirstOrDefault();
            return address;
        }

        public List<Address> GetAllCategories()
        {
            List<Address> lst = new List<Address>();
            SqlParameter[] param = new SqlParameter[]
           {
                    new SqlParameter("@Action",AddressAction.getAllAddress)
           };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_Address, param);
            //DataTable to list convertion
            lst = com.ConvertDataTable<Address>(dt);
            return lst;
        }

        public bool SaveAddress(Address address)
        {

            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",address.id),
                    new SqlParameter("@user_id",address.user_id),
                    new SqlParameter("@address1",address.address1),
                    new SqlParameter("@address2",address.address2),
                    new SqlParameter("@contry",address.contry),
                    new SqlParameter("@state",address.state),
                    new SqlParameter("@city",address.city),
                    new SqlParameter("@postal_code",address.postal_code),
                    new SqlParameter("@comment",address.comment),
                    new SqlParameter("@isactive",address.isactive),
                    new SqlParameter("@isdeleted",address.isdeleted),
                    new SqlParameter("@update_by",address.update_by),
                    new SqlParameter("@update_date",address.update_date),
                    new SqlParameter("@created_by",address.created_by),
                    new SqlParameter("@created_date",address.created_date),
                    new SqlParameter("@Action",AddressAction.insert),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_Address, param);
            n = res > 0 ? true : false;
            return n;

        }

        public bool Update(Address address)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",address.id),
                    new SqlParameter("@user_id",address.user_id),
                    new SqlParameter("@address1",address.address1),
                    new SqlParameter("@address2",address.address2),
                    new SqlParameter("@contry",address.contry),
                    new SqlParameter("@state",address.state),
                    new SqlParameter("@city",address.city),
                    new SqlParameter("@postal_code",address.postal_code),
                    new SqlParameter("@comment",address.comment),
                    new SqlParameter("@isactive",address.isactive),
                    new SqlParameter("@isdeleted",address.isdeleted),
                    new SqlParameter("@update_by",address.update_by),
                    new SqlParameter("@update_date",address.update_date),
                    new SqlParameter("@created_by",address.created_by),
                    new SqlParameter("@created_date",address.created_date),
                    new SqlParameter("@Action",AddressAction.update),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_Address, param);
            n = res > 0 ? true : false;
            return n;
        }

    }
}