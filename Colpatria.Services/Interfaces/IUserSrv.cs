using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.Services.Interfaces
{
    public interface IUserSrv
    {
        bool IsUser(string email, string pass);
    }
}
