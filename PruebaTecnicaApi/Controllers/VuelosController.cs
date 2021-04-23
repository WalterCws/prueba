using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaApi.Models;
using PruebaTecnicaCore.Entities;
using PruebaTecnicaCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private readonly IRepositorio<Vuelo> _iVuelo;

        public VueloController(IRepositorio<Vuelo> iVuelo)
        {
            _iVuelo = iVuelo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int statusCode = StatusCodes.Status200OK;
            var respuesta = new Respuesta(); throw new Exception();
           
            respuesta.Data =  await _iVuelo.ObtenerTodosAsync(p => p.CiudadOrigen.Departamento, p=> p.CiudadDestino.Departamento, p => p.Estado);
            
           
            return StatusCode(statusCode, respuesta);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            int statusCode = StatusCodes.Status200OK;
            var respuesta = new Respuesta();

            if (id < 0)
            {
                respuesta.Mensaje = Mensajes.NoSeEncuentra;
            }
            else 
            {
                respuesta.Data = await _iVuelo.ObtenerPorIdAsync(id);
            }
                
            return StatusCode(statusCode, respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vuelo Vuelo )
        {
            int statusCode = StatusCodes.Status200OK;
            var respuesta = new Respuesta();

            if (Vuelo == null || await _iVuelo.AnyFilterAsync(s => s.NumeroVuelo == Vuelo.NumeroVuelo && s.Estado == Vuelo.Estado && s.FechaSalida.Date >= Vuelo.FechaSalida.Date))
            {
                statusCode = StatusCodes.Status400BadRequest;
                respuesta.Mensaje = Mensajes.NoEsValida;
            }
            else
            {
                respuesta.Data = await _iVuelo.AgregarAsync(Vuelo);
            }
            
            return StatusCode(statusCode, _iVuelo.AgregarAsync(Vuelo));
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Vuelo Vuelo)
        {
            int statusCode = StatusCodes.Status200OK;
            var respuesta = new Respuesta();

            if ( id <=0 || Vuelo == null || !await _iVuelo.AnyFilterAsync(s => s.Id == id))
            {
                statusCode = StatusCodes.Status400BadRequest;
                respuesta.Mensaje = Mensajes.NoEsValida;
            }
            else
            {
                respuesta.Data = await _iVuelo.ActualizarAsync(Vuelo);
            }    
            return StatusCode(statusCode, respuesta);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            int statusCode = StatusCodes.Status200OK;
            var respuesta = new Respuesta();

            if (id <= 0 || !await _iVuelo.AnyFilterAsync(s => s.Id == id))
            {
                statusCode = StatusCodes.Status400BadRequest;
                respuesta.Mensaje = Mensajes.NoEsValida;
            }
            else
            {
                respuesta.Data = await _iVuelo.EliminarAsync(id);
            }           

            return StatusCode(StatusCodes.Status200OK, respuesta);
        }
    }
}
