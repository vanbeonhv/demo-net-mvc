using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DataAccess
{
    public static class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = null;
            try
            {
                var connectionString = File.ReadAllText("./appSetting.json");

                sqlConnection = new SqlConnection(connectionString);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception ex)
            {
                sqlConnection.Dispose();
            }

            return sqlConnection;
        }
    }
}