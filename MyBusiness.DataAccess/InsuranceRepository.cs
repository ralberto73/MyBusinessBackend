using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.DataAccess
{
    public class InsuranceRepository
    {
        private string _connection_string;
        private AdoSqlHelper db = null;
        public InsuranceRepository(string connection_string)
        {
            this._connection_string = connection_string;
            db = new AdoSqlHelper(connection_string);
        }

        public  List<Insurance> GetAll() =>  db.GetListFromSp<Insurance>("Insurances_GetAll", null, null);

        public Insurance GetById(int id) 
        {
                 return  db.GetListFromSp<Insurance>( "Insurances_GetById" 
                                                   ,new List<SqlParameter>() { new SqlParameter("@InsurancesId", System.Data.SqlDbType.Int) }
                                                   , id).FirstOrDefault<Insurance>();           
        }

        public bool Update(Insurance insurance , string user) 
        {
                  object result = db.GetValueFromSp<int>("Insurances_Update"
                                                  , new List<SqlParameter>() {  new SqlParameter("@InsuranceID",  System.Data.SqlDbType.Int),
                                                                                new SqlParameter("@InsuranceName", System.Data.SqlDbType.VarChar,100),
                                                                                new SqlParameter("@user",      System.Data.SqlDbType.VarChar,100) }
                                                  , insurance.InsuranceId
                                                  , insurance.InsuranceName
                                                  , user);
                  return true; // (result > 0);
         }

        public int AddNew(Insurance Insurance, string user)
        {
                  Object result = db.GetValueFromSp<int>("Insurances_AddNew"
                                      , new List<SqlParameter>() {   new SqlParameter("@InsuranceName", System.Data.SqlDbType.VarChar,100),
                                                                     new SqlParameter("@user",      System.Data.SqlDbType.VarChar,100) }
                                      , Insurance.InsuranceName
                                      , user);
                  return Convert.ToInt32(result);
        }

               /*          public int Delete(Insurance Insurance)
              {
                  Object result = db.GetValueFromSp<int>("Insurances_Delete"
                                      , new List<SqlParameter>() { new SqlParameter("@BarandID", System.Data.SqlDbType.Int) }
                                      , Insurance.InsuranceId);
                  return Convert.ToInt32(result);
              }
      */

    }
}

