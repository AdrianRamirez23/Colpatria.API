using Colpatria.Application.Contracts;
using Colpatria.Application.Interfaces;
using Colpatria.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colpatria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SoatController : ControllerBase
    {
        //Se relaciona la capa Aplication por medio de la llamada a la interface
        private readonly ISoatApp _soat;
        public SoatController(ISoatApp soatApp)
        {
            _soat = soatApp;
        }
        /// <summary>
        /// Crear o realizar una venta de soat
        /// </summary>
        /// <param name="soatAutomotor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("VenderSoat")]
        public IActionResult VenderSoat(SoatAutomotor soatAutomotor)
        {
            try
            {
                //Valida si el objeto recibido es válido
                if (ModelState.IsValid)
                {
                    //Realiza la creación del código de la poóliza con un guid unico automático en caso de que no regrese lleno el campo
                    soatAutomotor.Cod_Poliza = (string.IsNullOrEmpty(soatAutomotor.Cod_Poliza) ? Guid.NewGuid().ToString() : soatAutomotor.Cod_Poliza);
                    //captura el resultado 
                    var result = _soat.venderSoat(soatAutomotor);
                    if(result > 0)
                    {
                        //Devuelve Ok, un mensaje de aprobación y la cantidad de registros generados.
                        return Ok(new
                        {
                            Estado = true,
                            Mensaje = "Venta realizada correctamente",
                            Resutado = result
                        });
                    }
                    else
                    {
                       return BadRequest("Error al intentar guardar la venta");
                    }
                }
                else
                {
                    //retorna petición errada en el cuerpo del post
                    return BadRequest("Error en la petición");
                }

            }
            catch (Exception ex)
            {
                //Captura el error en caso de ocurrir
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Consultar/{id}")]
        public IActionResult Consulta([FromRoute] string id) 
        {
            try
            {
                var result = _soat.Consultar(id);
                if(result != null)
                {
                    return Ok(new
                    {
                        Estado = true,
                        Mensaje = "Consulta Existosa",
                        Resultado = result
                    });
                }
                else
                {
                    return NotFound("Consulta no existosa");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
