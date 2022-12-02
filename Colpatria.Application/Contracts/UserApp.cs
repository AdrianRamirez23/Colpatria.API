using Colpatria.Application.Interfaces;
using Colpatria.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.Application.Contracts
{
    public class UserApp: IUserApp
    {
        private readonly IUserSrv userSrv;
        public UserApp(IUserSrv _userSrv)
        {
            userSrv = _userSrv;
        }
        public  bool IsUser(string email, string pass)
        {
            return userSrv.IsUser(email, pass);
        }
    }
}
