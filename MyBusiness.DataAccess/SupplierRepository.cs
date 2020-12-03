using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.DataAccess
{
    public class SupplierRepository
    {
        private string _connection_string;
        private AdoSqlHelper db = null;
        public SupplierRepository(string connection_string)
        {
            this._connection_string = connection_string;
            db = new AdoSqlHelper(connection_string);
        }

        public  List<Supplier> GetAll() =>  db.GetListFromSp<Supplier>("Suppliers_GetAll", null, null);

        public Supplier GetById(int id) 
        {
           return  db.GetListFromSp<Supplier>( "Suppliers_GetById" 
                                             ,new List<SqlParameter>() { new SqlParameter("@BarandID", System.Data.SqlDbType.Int) }
                                             , id).FirstOrDefault<Supplier>();
        }

        public bool Update(Supplier Supplier , string user) 
        {
            object result = db.GetValueFromSp<int>("Suppliers_Update"
                                            , new List<SqlParameter>() {  new SqlParameter("@BarandID",  System.Data.SqlDbType.Int),
                                                                          new SqlParameter("@SupplierName", System.Data.SqlDbType.VarChar,100),
                                                                          new SqlParameter("@user",      System.Data.SqlDbType.VarChar,100) }
                                            , Supplier.SupplierId
                                            , Supplier.SupplierName
                                            , user);
            return true; // (result > 0);
        }

        public int AddNew(Supplier Supplier, string user)
        {
            Object result = db.GetValueFromSp<int>("Suppliers_AddNew"
                                , new List<SqlParameter>() {   new SqlParameter("@SupplierName", System.Data.SqlDbType.VarChar,100),
                                                               new SqlParameter("@user",      System.Data.SqlDbType.VarChar,100) }
                                , Supplier.SupplierName
                                , user);
            return Convert.ToInt32(result);
        }

        public int Delete(int id)
        {
            Object result = db.GetValueFromSp<int>("Suppliers_Delete"
                                , new List<SqlParameter>() { new SqlParameter("@BarandID", System.Data.SqlDbType.Int) }
                                , id);
            return Convert.ToInt32(result);
        }


    }
}

