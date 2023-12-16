using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccessObject;
using DataAccess.DataObject;

namespace DataAccess.DataAccessObjectImpl
{
    public class UserDaoImpl : IUserDao
    {
        public int Login(string email, string password)
        {
            try
            {
                var con = DbHelper.GetConnection();
                var cmd = new SqlCommand("login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                SqlParameter sqlParameter = cmd.Parameters.Add("@HttpStatusReturn", SqlDbType.Int);
                sqlParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                int httpStatusReturn = (int)cmd.Parameters["@HttpStatusReturn"].Value;
                return httpStatusReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public HttpStatusCode AddNewUser(string email, string password)
        {
            try
            {
                var con = DbHelper.GetConnection();
                var cmd = new SqlCommand("add_new_user", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                int numberOfAffectedRow = cmd.ExecuteNonQuery();
                return numberOfAffectedRow > 0 ? HttpStatusCode.Created : HttpStatusCode.Conflict;
            }
            catch (SqlException e)
            {
                if (e.Number == 50001)
                {
                    //Email already exits
                    return HttpStatusCode.Conflict;
                }

                throw;
            }
        }
    }
}