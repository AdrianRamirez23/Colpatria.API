using Colpatria.Entities.Models;
using Colpatria.Services.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.Services.Contracts
{
     public class SoatSrv: ISoatSrv
    {
        private readonly IConfiguration config;

        public SoatSrv(IConfiguration conf)
        {
            config = conf;
        }

        public int venderSoat(SoatAutomotor soatAutomotor)
        {
            int result = 0;
            // Llena los parámetros que requiere el SP de SQL Server
            var parameters = new
            {
                Cod_Poliza = soatAutomotor.Cod_Poliza,
                TipoId = soatAutomotor.TipoIdentificacionTomador,
                Id = soatAutomotor.IdentificacionTomador,
                Nombre = soatAutomotor.NombreTomador,
                FechaInicio = soatAutomotor.FechaInicio,
                FechaFin = soatAutomotor.FechaFin,
                FechaVencimiento = soatAutomotor.FechaVencimientoPolizaActual,
                Placa = soatAutomotor.PlacaAutomotor,
                CodCiudadVenta = soatAutomotor.CodCiudadVenta
            };
            //realiza la ejecución del Procedimiento de Almacenado usando como ORM Dapper
            using (var con = new SqlConnection( config.GetConnectionString("ConnectionDB")))
            {
                result = con.Execute("dbo.VenderPoliza", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
        public List<SoatAutomotor> Consulta(string id)
        {
            List<SoatAutomotor> result = null;
            // Llena los parámetros que requiere el SP de SQL Server
            var parameters = new
            {
               placa = id,
               id = id
            };
            //realiza la ejecución del Procedimiento de Almacenado usando como ORM Dapper
            using (var con = new SqlConnection(config.GetConnectionString("ConnectionDB")))
            {
                result = con.Query<SoatAutomotor>("dbo.ConsultarSoat", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
            return result;
        }
    }
}
