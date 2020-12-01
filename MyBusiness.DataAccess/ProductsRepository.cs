using MyBusiness.Models;
using System;
using System.Collections.Generic;

namespace MyBusiness.DataAccess
{
    public class ProductsRepository
    {
        public ProductsRepository(string connection_string)
        {
            Connection_string = connection_string;
        }

        public string Connection_string { get; }

        public List<Product> GetAll() {

            return new List<Product>() { new Product { ProductId = 1, ProdCategoryId = 1, ProductName = "Product 1", CreatedBy = "sa", UpdatedBy = "sa", 
                       CreationDate = DateTime.Now  , LastUpdateDate = DateTime.Now  } }; 
        }
    }
}