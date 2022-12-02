using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.Application.Interfaces
{
    public interface IUserApp
    {
        bool IsUser(string email, string pass);
    }
}
