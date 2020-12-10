using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.DataAccess
{
    public class BrandRepository
    {
        private string _connection_string;
        private AdoSqlHelper db = null;
        public BrandRepository(string connection_string)
        {
            this._connection_string = connection_string;
            db = new AdoSqlHelper(connection_string);
        }

        public  List<Brand> GetAll() =>  db.GetListFromSp<Brand>("Brands_GetAll", null, null);

        public Brand GetById(int id) 
        {
           return  db.GetListFromSp<Brand>( "Brands_GetById" 
                                             ,new List<SqlParameter>() { new SqlParameter("@BarandID", System.Data.SqlDbType.Int) }
                                             , id).FirstOrDefault<Brand>();
        }

        public bool Update(Brand brand , string user) 
        {
            object result = db.GetValueFromSp<int>("Brands_Update"
                                            , new List<SqlParameter>() {  new SqlParameter("@BarandID",  System.Data.SqlDbType.Int),
                                                                          new SqlParameter("@BrandName", System.Data.SqlDbType.VarChar,100),
                                                                          new SqlParameter("@user",      System.Data.SqlDbType.VarChar,100) }
                                            , brand.BrandId
                                            , brand.BrandName
                                            , user);
            return true; // (result > 0);
        }

        public int AddNew(Brand brand, string user)
        {
            Object result = db.GetValueFromSp<int>("Brands_AddNew"
                                , new List<SqlParameter>() {   new SqlParameter("@BrandName", System.Data.SqlDbType.VarChar,100),
                                                               new SqlParameter("@user",      System.Data.SqlDbType.VarChar,100) }
                                , brand.BrandName
                                , user);
            return Convert.ToInt32(result);
        }

        public int Delete(Brand brand)
        {
            Object result = db.GetValueFromSp<int>("Brands_Delete"
                                , new List<SqlParameter>() { new SqlParameter("@BarandID", System.Data.SqlDbType.Int) }
                                , brand.BrandId);
            return Convert.ToInt32(result);
        }

        public int Delete(int BrandId)
        {
            Object result = db.GetValueFromSp<int>("Brands_Delete"
                                , new List<SqlParameter>() { new SqlParameter("@BarandID", System.Data.SqlDbType.Int) }
                                , BrandId);
            return Convert.ToInt32(result);
        }
    }
}

