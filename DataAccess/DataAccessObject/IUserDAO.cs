using System;
using System.Collections.Generic;
using System.Net;
using DataAccess.DataObject;

namespace DataAccess.DataAccessObject
{
    public interface IUserDao
    {
        int Login(string email, string password);
        HttpStatusCode AddNewUser(string email, string password);
        List<User> GetListUser();
        User GetUer(Guid id);
        int UpdateUser(User user);
    }
}