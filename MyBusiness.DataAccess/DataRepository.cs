using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.DataAccess
{
    public class DataRepository : IDataRepository
    {
        private string _connection_string;

        public WorkOrderRepository WorkOrders { get; }
        public ProductsRepository Products { get; }

        public BrandRepository Brand { get; }
        public DataRepository(string connection_string)
        {
            _connection_string = connection_string;
            WorkOrders = new WorkOrderRepository(_connection_string);
            Products   = new ProductsRepository(_connection_string);
            Brand     = new BrandRepository(_connection_string);

        }


    }
}
