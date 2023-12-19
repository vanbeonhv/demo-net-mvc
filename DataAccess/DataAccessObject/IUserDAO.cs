using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataObject;

namespace DataAccess.DataAccessObject
{
    public interface IUserDao
    {
        int Login(string email, string password);
        HttpStatusCode AddNewUser(string email, string password);
        List<User> GetListUser();
    }
}