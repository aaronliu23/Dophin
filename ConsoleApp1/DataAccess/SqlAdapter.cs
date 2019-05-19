using System;

using System.Data;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
 public  class SqlAdapter
  {
    private string _sqlConnectionStr;

    public SqlAdapter(string sqlConnectionStr)
    {
      _sqlConnectionStr = sqlConnectionStr;
    }

    public bool ExcuteSQLCommand( string sqlCommandStr, Dictionary<string, object> sqlParams)
    {
      var result = false;
      //generate connection
      using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStr))
      {
        //generate sql command
        using (SqlCommand sqlCommand = new SqlCommand(sqlCommandStr, sqlConnection))
        {
          sqlCommand.CommandType = CommandType.Text;
          if (sqlParams != null)
          {
            if (sqlParams.Count > 0)
            {
              foreach (var item in sqlParams)
              {
                sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
              }
            }
          }

          try
          {
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            result = true;
            return result;
          }
          catch (SqlException ex)
          {
            sqlConnection.Close();
            result = false;
            throw ex;
          }
        }
      }
    }
  }
}
