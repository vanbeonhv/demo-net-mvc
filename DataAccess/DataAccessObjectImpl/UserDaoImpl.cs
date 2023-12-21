using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.InteropServices;
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

        public List<User> GetListUser()
        {
            var userList = new List<User>();
            try
            {
                var con = DbHelper.GetConnection();
                var cmd = new SqlCommand("get_list_user", con);
                cmd.CommandType = CommandType.StoredProcedure;
                var data = cmd.ExecuteReader();

                while (data.Read())
                {
                    var user = new User()
                    {
                        Id = (Guid)data["id"],
                        Email = data["email"].ToString(),
                        Password = data["password"].ToString(),
                        Address = data["address"].ToString(),
                        Age = Convert.ToInt32(data["age"]),
                    };
                    userList.Add(user);
                }

                return userList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public User GetUer(Guid id)
        {
            var user = new User();
            try
            {
                var con = DbHelper.GetConnection();
                var cmd = new SqlCommand("get_user_by_id", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var data = cmd.ExecuteReader();

                while (data.Read())
                {
                    user.Id = (Guid)data["id"];
                    user.Email = data["email"].ToString();
                    user.Password = data["password"].ToString();
                    user.Address = data["address"].ToString();
                    user.Age = Convert.ToInt32(data["age"]);
                }

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int UpdateUser(User user)
        {
            var res = 0;
            try
            {
                var con = DbHelper.GetConnection();
                var cmd = new SqlCommand("update_user", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@address", user.Address);
                cmd.Parameters.Add("@responseCode", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                res = cmd.Parameters["@responseCode"].Value == DBNull.Value
                    ? 0
                    : Convert.ToInt32(cmd.Parameters["@responseCode"].Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return res;
        }
    }
}