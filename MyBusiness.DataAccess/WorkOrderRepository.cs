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
    public class WorkOrderRepository
    {
        private string       _connection_string;
        private AdoSqlHelper db = null;
        public WorkOrderRepository( string connection_string)
        {
            this._connection_string = connection_string;
            db = new AdoSqlHelper(connection_string);
        }


        /// <summary>
        ///  Get the List of Work Orders 
        /// </summary>
        /// <param name="from">from </param>
        /// <param name="to"></param>
        /// <returns></returns>
        /// 

        public List<WorkOrderListModel> DameData(DateTime? from, DateTime? to)
        {

            return db.GetListFromSp<WorkOrderListModel>("GetWorkOrders",
                                                     new List<SqlParameter>() { new SqlParameter("@From", System.Data.SqlDbType.DateTime) ,
                                                                                new SqlParameter("@To", System.Data.SqlDbType.DateTime) },
                                                     DateTime.Now,
                                                     DateTime.Now
                                                     );
        }

   



 
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
         public async Task<List<WorkOrderListModel>> GetAllWorkOrdersAsync(DateTime? from, DateTime? to)
        {
            //   Declares the result List 
            var result_list = new List<WorkOrderListModel>();

            using (SqlConnection sql = new SqlConnection(_connection_string))
            {
                using (SqlCommand cmd = new SqlCommand("GetWorkOrders", sql))
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
                            var r = MapValues<WorkOrderListModel>(reader);
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