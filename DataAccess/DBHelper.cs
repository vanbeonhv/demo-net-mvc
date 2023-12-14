using System.Data.SqlClient;

namespace DataAccess
{
    public class DBHelper
    {
        public SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = null;
            return new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
        }
    }
}