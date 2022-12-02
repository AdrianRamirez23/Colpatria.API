using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.Entities.Models
{
    public class SoatAutomotor
    {
        public int idSoat { get; set; }
        public string Cod_Poliza { get; set; }
        public string TipoIdentificacionTomador  { get; set; }
        public string IdentificacionTomador { get; set; }
        public string NombreTomador { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime? FechaVencimientoPolizaActual { get; set; }
        public string PlacaAutomotor { get; set; }
        public string CodCiudadVenta { get; set; }
    }
}
