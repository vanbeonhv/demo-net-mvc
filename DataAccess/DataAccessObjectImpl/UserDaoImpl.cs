using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataAccessObject;
using DataAccess.DataObject;

namespace DataAccess.DataAccessObjectImpl
{
    public class UserDaoImpl : IUserDao
    {
        public User GetUser()
        {
            try
            {
                var con = DbHelper.GetConnection();
                var cmd = new SqlCommand("get_user", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", "87a9850b-6eda-48b9-974e-8c2a2381a498");

                var data = cmd.ExecuteReader();
                var user = new User();
                while (data.Read())
                {
                    user.Id = data["id"] != DBNull.Value ? (Guid)data["id"] : Guid.Empty;
                    user.Email = data["email"] as string;
                    user.Password = data["password"] as string;
                }

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}