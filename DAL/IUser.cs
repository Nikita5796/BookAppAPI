using demoAuthApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoAuthApp.DAL
{
    public interface IUser
    {
        List<User> GetUsers();
    }
}
