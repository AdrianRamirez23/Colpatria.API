using Colpatria.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.Services.Interfaces
{
    public interface ISoatSrv
    {
        int venderSoat(SoatAutomotor soat);
        List<SoatAutomotor> Consulta(string id);
    }
}
