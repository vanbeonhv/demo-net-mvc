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
                var connectionString =
                    "Data Source=SQL5112.site4now.net;Initial Catalog=db_aa2e52_mydb;User Id=db_aa2e52_mydb_admin;Password=Linhtinh123@";

                sqlConnection = new SqlConnection(connectionString);
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception ex)
            {
                sqlConnection?.Dispose();
                Console.WriteLine(ex);
            }

            return sqlConnection;
        }
    }
}