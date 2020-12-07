using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBusiness.DataAccess
{
    public class ServiceOrderRepository
    {
        private string       _connection_string;
        private AdoSqlHelper db = null;
        public ServiceOrderRepository( string connection_string)
        {
            this._connection_string = connection_string;
            db = new AdoSqlHelper(connection_string);
        }

        //  Get all Service orders 
        public List<ServiceOrder> GetAll() => db.GetListFromSp<ServiceOrder>("ServiceOrders_GetAll", null, null);

        public int AddNew(ServiceOrder new_service )
        {
            Object result = db.GetValueFromSp<int>("ServiceOrders_AddNew"
                                , new List<SqlParameter>() {   new SqlParameter("@ServiceOrderStatusId ",    System.Data.SqlDbType.Int)
                                                              ,new SqlParameter("@Contact",                  System.Data.SqlDbType.VarChar,50)  
                                                              ,new SqlParameter("@Email",                    System.Data.SqlDbType.VarChar,50) 
                                                              ,new SqlParameter("@PhoneNumber",              System.Data.SqlDbType.VarChar,20)
                                                              ,new SqlParameter("@AddressLine1",             System.Data.SqlDbType.VarChar,50)
                                                              ,new SqlParameter("@AddressLine2",             System.Data.SqlDbType.VarChar,50)
                                                              ,new SqlParameter("@City",                     System.Data.SqlDbType.VarChar,50)
                                                              ,new SqlParameter("@State",                    System.Data.SqlDbType.VarChar,3)
                                                              ,new SqlParameter("@ZipCode",                  System.Data.SqlDbType.VarChar,12)
                                                              ,new SqlParameter("@BrandId",                  System.Data.SqlDbType.Int)
                                                              ,new SqlParameter("@Model",                    System.Data.SqlDbType.VarChar, 50)
                                                              ,new SqlParameter("@SubModel",                 System.Data.SqlDbType.VarChar,50 )
                                                              ,new SqlParameter("@Year",                     System.Data.SqlDbType.Int)
                                                              ,new SqlParameter("@ProductId",                System.Data.SqlDbType.Int)
                                                              ,new SqlParameter("@PaymentMethod",            System.Data.SqlDbType.Char,1)
                                                              ,new SqlParameter("@InsuranceId",               System.Data.SqlDbType.Int)
                                                              ,new SqlParameter("@SupplierId",               System.Data.SqlDbType.Int)                                                             
                                                              ,new SqlParameter("@BillableAmount",           System.Data.SqlDbType.Decimal,18)
                                                              ,new SqlParameter("@LaborAmount",              System.Data.SqlDbType.Decimal,18)
                                                              ,new SqlParameter("@PartCost",                 System.Data.SqlDbType.Decimal,18)  
                                                              ,new SqlParameter("@User",                     System.Data.SqlDbType.VarChar,100)           
                                                         }
                                , new_service.ServiceOrderStatusId
                                , new_service.Contact
                                ,new_service.Email
                                ,new_service.PhoneNumber
                                ,new_service.AddressLine1
                                , new_service.AddressLine2
                                , new_service.City
                                , new_service.State
                                , new_service.ZipCode
                                , new_service.BrandId
                                , new_service.Model
                                , new_service.SubModel
                                , new_service.Year
                                , new_service.ProductId
                                , new_service.PaymentMethod
                                , new_service.InsuranceId
                                , new_service.SupplierId
                                , new_service.BillableAmount
                                , new_service.LaborAmount
                                , new_service.PartCost
                                , new_service.CreatedBy
                                );
            return Convert.ToInt32(result);
        }


        /*
        /// <summary>
        ///  Get the List of Work Orders 
        /// </summary>
        /// <param name="from">from </param>
        /// <param name="to"></param>
        /// <returns></returns>
        /// 

        public List<ServiceOrderListModel> DameData(DateTime? from, DateTime? to)
        {

            return db.GetListFromSp<ServiceOrderListModel>("GetServiceOrders",
                                                     new List<SqlParameter>() { new SqlParameter("@From", System.Data.SqlDbType.DateTime) ,
                                                                                new SqlParameter("@To", System.Data.SqlDbType.DateTime) },
                                                     DateTime.Now,
                                                     DateTime.Now
                                                     );
        }

   
        */



    }
}


/*
 
     public List<T> GetListFromSp<T>(string procedure_name, List<SqlParameter> sql_parameters, params object[] params_values) where T : new()
        {
            List<T> result_list = new List<T>();

            using (SqlConnection sql = new SqlConnection(_connection_string))
            {
                using (SqlCommand cmd = new SqlCommand(procedure_name, sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //  Fills  All Sp Parameters
                    if (sql_parameters != null && sql_parameters.Count > 0 && sql_parameters.Count == params_values.Length)
                    {
                        foreach (SqlParameter parameter in sql_parameters)
                        {
                            cmd.Parameters.Add(parameter);
                            cmd.Parameters[parameter.ParameterName].Value = params_values[0];
                        }
                    }
                    sql.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //   var a = reader.GetColumnSchema();
                            var r = MapValues<T>(reader);
                            result_list.Add(r);
                        }
                    }
                }
            }
            return result_list;
        }
----------------
         public async Task<List<ServiceOrderListModel>> GetAllServiceOrdersAsync(DateTime? from, DateTime? to)
        {
            //   Declares the result List 
            var result_list = new List<ServiceOrderListModel>();

            using (SqlConnection sql = new SqlConnection(_connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("GetServiceOrders", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@From", System.Data.SqlDbType.DateTime));
                    cmd.Parameters["@From"].Value = from;
                    cmd.Parameters.Add(new SqlParameter("@To", System.Data.SqlDbType.DateTime));
                    cmd.Parameters["@To"].Value = to;

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            //   var a = reader.GetColumnSchema();
                            var r = MapValues<ServiceOrderListModel>(reader);
                            result_list.Add(r);
                        }
                    }

                    return result_list;
                }
            }
        }


-----------------------------------------
 
        public List<T> GetListFromSp<T>(string procedure_name, List<SqlParameter> sql_parameters, params object[] params_values) where T : new()
        {
            List<T> result_list = new List<T>();

            using (SqlConnection sql = new SqlConnection(_connection_string))
            {
                using (SqlCommand cmd = new SqlCommand(procedure_name, sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //  Fills  All Sp Parameters
                    if (sql_parameters != null && sql_parameters.Count > 0 && sql_parameters.Count == params_values.Length)
                    {
                        foreach (SqlParameter parameter in sql_parameters)
                        {
                            cmd.Parameters.Add(parameter);
                            cmd.Parameters[parameter.ParameterName].Value = params_values[0];
                        }
                    }
                    sql.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //   var a = reader.GetColumnSchema();
                            var r = MapValues<T>(reader);
                            result_list.Add(r);
                        }
                    }
                }
            }
            return result_list;
        }
------------------------------------------
public async Task<List<Value>> GetAll()
{
    using (SqlConnection sql = new SqlConnection(_connectionString))
    {
        using (SqlCommand cmd = new SqlCommand("GetAllValues", sql))
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<Value>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(MapToValue(reader));
                }
            }

            return response;
        }
    }
}

       private T MapValues<T>(SqlDataReader reader) where T : new()
        {
            T result = new T();
            // var columnShemas = ;

            foreach (var schema in reader.GetColumnSchema())
            {
                var property_name = schema.ColumnName.Trim();
                var type = result.GetType();
                // Get the PropertyInfo object by passing the property name.
                PropertyInfo myPropInfo = type.GetProperty(property_name);
                if (myPropInfo != null)
                    // Fill  the property.
                    myPropInfo.SetValue(result, reader[property_name], null);
            }
            return result;
        }

} */