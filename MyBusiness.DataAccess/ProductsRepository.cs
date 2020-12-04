using MyBusiness.Models;
using System;
using System.Collections.Generic;

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

        //public List<Product> GetAll() {

        //    return new List<Product>() { new Product { ProductId = 1, ProdCategoryId = 1, ProductName = "Product 1", CreatedBy = "sa", UpdatedBy = "sa", 
        //               CreationDate = DateTime.Now  , LastUpdateDate = DateTime.Now  } }; 
        //}
    }
}