using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyBusiness.DataAccess
{
    public interface IAdoSqlHelper
    {
        List<T> GetListFromSp<T>(string procedure_name, List<SqlParameter> sql_parameters, params object[] params_values) where T : new();
    }
}