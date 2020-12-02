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

        public BrandRepository Brand { get; }
        public InsuranceRepository Insurances { get; }
        public SupplierRepository Suppliers { get; }

        //----------------------------------------------
        public WorkOrderRepository WorkOrders { get; }
        public ProductsRepository Products { get; }

        
        public DataRepository(string connection_string)
        {
            _connection_string = connection_string;
            Brand      = new BrandRepository(_connection_string);
            Insurances = new InsuranceRepository(_connection_string);
            Suppliers = new SupplierRepository(_connection_string);
            WorkOrders = new WorkOrderRepository(_connection_string);
            Products   = new ProductsRepository(_connection_string);
          

        }


    }
}
