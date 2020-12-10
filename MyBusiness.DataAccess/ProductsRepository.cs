using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MyBusiness.DataAccess
{
    public class ProductsRepository
    {
        private string _connection_string;
        private AdoSqlHelper db = null;
        public ProductsRepository(string connection_string)
        {
            this._connection_string = connection_string;
            db = new AdoSqlHelper(connection_string);
        }
        public List<Product> GetAll() => db.GetListFromSp<Product>("Products_GetAll", null, null);

        public Product GetById(int id)
        {
            return db.GetListFromSp<Product>("Products_GetById"
                                              , new List<SqlParameter>() { new SqlParameter("@Id", System.Data.SqlDbType.Int) }
                                              , id).FirstOrDefault<Product>();
        }


        public int AddNew(Product product, string user)
        {
            Object result = db.GetValueFromSp<int>("Products_AddNew"
                                , new List<SqlParameter>() {   new SqlParameter("@ProductName", System.Data.SqlDbType.VarChar,100),
                                                                     new SqlParameter("@user",      System.Data.SqlDbType.VarChar,100) }
                                , product.ProductName
                                , user);
            return Convert.ToInt32(result);
        }




        /// <summary>
        /// Updates  the Product
        /// </summary>
        /// <param name="product">Object Class Product</param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(Product product, string user)
        {
            //   the ProdCategoryId  will be required in the future 
            //   For now  ProdCategoryId = 0 
            object result = db.GetValueFromSp<int>("Products_Update"
                                            , new List<SqlParameter>() {  new SqlParameter("@Id"             , System.Data.SqlDbType.Int),
                                                                          new SqlParameter("@ProdCategoryId" , System.Data.SqlDbType.Int),
                                                                          new SqlParameter("@Name"           , System.Data.SqlDbType.NVarChar,100),
                                                                          new SqlParameter("@user",      System.Data.SqlDbType.NVarChar,100) }
                                            , product.ProductId
                                            ,0
                                            , product.ProductName
                                            , user);
            return true; // (result > 0);
        }

        public int Delete(int id)
        {
            Object result = db.GetValueFromSp<int>("Products_Delete"
                                , new List<SqlParameter>() { new SqlParameter("@Id", System.Data.SqlDbType.Int) }
                                , id);
            return Convert.ToInt32(result);
        }

        public int Delete(Product product)
        {
            return this.Delete(product.ProductId);
        }
    }
}