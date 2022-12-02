using Colpatria.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.Application.Interfaces
{
    public interface ISoatApp
    {
        int venderSoat(SoatAutomotor soat);
        List<SoatAutomotor> Consultar(string id);
    }
}
