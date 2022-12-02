using Colpatria.Application.Interfaces;
using Colpatria.Entities.Models;
using Colpatria.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.Application.Contracts
{
    public class SoatApp: ISoatApp
    {
        //Se hace referencia a la capa de servicios
        private readonly ISoatSrv soat;
        public SoatApp(ISoatSrv _soat)
        {
            soat = _soat;
        }
        public int venderSoat(SoatAutomotor soatAutomotor)
        {
            return soat.venderSoat(soatAutomotor);
        }
        public List<SoatAutomotor> Consultar(string id)
        {
            return soat.Consulta(id);
        }
    }
}
