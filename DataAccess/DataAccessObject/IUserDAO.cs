using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataObject;

namespace DataAccess.DataAccessObject
{
    public interface IUserDao
    {
        User GetUser();
    }
}