using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.DataAccess
{
        public class ServiceOrderStatusRepository
        {
            private string _connection_string;
            private AdoSqlHelper db = null;
            public ServiceOrderStatusRepository(string connection_string)
            {
                this._connection_string = connection_string;
                db = new AdoSqlHelper(connection_string);
            }

            public List<ServiceOrderStatus> GetAll() => db.GetListFromSp<ServiceOrderStatus>("ServiceOrderStatus_GetAll", null, null);

        public ServiceOrderStatus GetById(int id )
        {
            return db.GetListFromSp<ServiceOrderStatus>("ServiceOrderStatus_GetById"
                                  , new List<SqlParameter>() { new SqlParameter("@Id", System.Data.SqlDbType.Int) }
                                  , id).FirstOrDefault<ServiceOrderStatus>();
        }

        public bool Update(ServiceOrderStatus service_order_status, string user)
            {
                object result = db.GetValueFromSp<int>("ServiceOrderStatus_Update"
                                                , new List<SqlParameter>() {  new SqlParameter("@ServiceOrderStatusId", System.Data.SqlDbType.Int),
                                                                              new SqlParameter("@StatusName"          , System.Data.SqlDbType.VarChar,20),
                                                                              new SqlParameter("@Color"               , System.Data.SqlDbType.VarChar,20),
                                                                              new SqlParameter("@IconPicture"         , System.Data.SqlDbType.VarChar, 50),
                                                                              new SqlParameter("@User"                , System.Data.SqlDbType.VarChar, 100) }
                                                , service_order_status.ServiceOrderStatusId
                                                , service_order_status.StatusName
                                                , service_order_status.Color
                                                , service_order_status.IconPicture
                                                , user);
                return true; // (result > 0);
            }

        public int Delete(int id)
        {
            Object result = db.GetValueFromSp<int>("ServiceOrderStatus_Delete"
                    , new List<SqlParameter>() { new SqlParameter("@Id", System.Data.SqlDbType.Int) }
                    , id);
            return Convert.ToInt32(result);
        }

        public int AddNew(ServiceOrderStatus service_order_status, string user)
            {
                Object result = db.GetValueFromSp<int>("ServiceOrderStatus_AddNew"
                                    , new List<SqlParameter>() {  new SqlParameter("@Name"          , System.Data.SqlDbType.VarChar,20),
                                                                  new SqlParameter("@Color"               , System.Data.SqlDbType.VarChar,20),
                                                                  new SqlParameter("@IconPicture"         , System.Data.SqlDbType.VarChar, 50),
                                                                  new SqlParameter("@User"                , System.Data.SqlDbType.VarChar, 100) }
                                    , service_order_status.StatusName
                                    , service_order_status.Color
                                    , service_order_status.IconPicture
                                    , user);
                return Convert.ToInt32(result);
            }
/*
            public int Delete(Brand brand)
            {
                Object result = db.GetValueFromSp<int>("Brands_Delete"
                                    , new List<SqlParameter>() { new SqlParameter("@BarandID", System.Data.SqlDbType.Int) }
                                    , brand.BrandId);
                return Convert.ToInt32(result);
            }
*/

        }
    
}