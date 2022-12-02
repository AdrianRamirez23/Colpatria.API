using Colpatria.Entities.Models;
using Colpatria.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.Services.Contracts
{
    public class UserSrv: IUserSrv
    {
        List<User> users = new List<User>()
        {
            new User(){email ="admin@correo.com", password = "correo123"},
            new User(){email ="user@correo.com", password = "user123"}
        };
        public bool IsUser(string email, string pass) => users.Where(u => u.email == email && u.password == pass).Count() > 0;
        
    }
}
