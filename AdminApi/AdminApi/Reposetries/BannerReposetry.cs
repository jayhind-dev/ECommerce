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
    public class BannerReposetry : IBannerReposetry
    {
        DataAccess dataAccess = new DataAccess();
        Common com = new Common();

        public bool BannerDelete(int id)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",id),
                    new SqlParameter("@Action",BannerAction.delete),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_Banner, param);
            n = res > 0 ? true : false;
            return n;
        }

        public banner BannerEdit(int id)
        {
            List<banner> list = new List<banner>();
            banner banner = new banner();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@id",id),
            new SqlParameter("@Action", BannerAction.Edit),
            };
        DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_Banner, param);
            list = com.ConvertDataTable<banner>(dt);
            banner = list.FirstOrDefault();
            return banner;
        }

        public bool BannerUpdate(banner banner)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",banner.id),
                    new SqlParameter("@image",banner.image),
                    new SqlParameter("@content",banner.content),
                    new SqlParameter("@type",banner.type),
                    new SqlParameter("@order_type",banner.order_type),
                    new SqlParameter("@width",banner.width),
                    new SqlParameter("@hiegth",banner.hiegth),
                    new SqlParameter("@isactive",true),
                    new SqlParameter("@isdeleted",false),
                    new SqlParameter("@updated_by",banner.updated_by),
                    new SqlParameter("@updated_date",banner.updated_date),
                    new SqlParameter("@Action",BannerAction.update),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_Banner, param);
            n = res > 0 ? true : false;
            return n;
        }

        public List<banner> GeltAllBanner()
        {
            List<banner> lst = new List<banner>();
            SqlParameter[] param = new SqlParameter[]
           {
                    new SqlParameter("@Action",BannerAction.getAllbanner)
           };
            DataTable dt = dataAccess.ExecProcDataTable(SPKeys.p_Banner, param);
            //DataTable to list convertion
            lst = com.ConvertDataTable<banner>(dt);
            return lst;
        }

        public bool SaveBanner(banner banner)
        {
            bool n = false;
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@id",banner.id),
                    new SqlParameter("@image",banner.image),
                    new SqlParameter("@content",banner.content),
                    new SqlParameter("@type",banner.type),
                    new SqlParameter("@order_type",banner.order_type),
                    new SqlParameter("@width",banner.width),
                    new SqlParameter("@hiegth",banner.hiegth),
                    new SqlParameter("@isactive",true),
                    new SqlParameter("@isdeleted",false),
                    new SqlParameter("@create_by",banner.create_by),
                    new SqlParameter("@Action",BannerAction.insert),
            };
            int res = dataAccess.ExecuteNonQueryProc(SPKeys.p_Banner, param);
            n = res > 0 ? true : false;
            return n;
        }
    }
}