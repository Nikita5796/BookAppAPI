using demoAuthApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoAuthApp.Service
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        //IEnumerable<User> GetUsers();
        IList<User> GetUsers();
    }
}
