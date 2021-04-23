using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PruebaTecnicaCore.Entities;
using PruebaTecnicaWeb.Models;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace PruebaTecnicaWeb.Areas.Vuelos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public void OnGet()
        {
        }

        [HttpGet]
        public async Task<IActionResult>  OnGetListarVuelos()
        {
            int statusCode = StatusCodes.Status200OK;
            List<Vuelo> salida = new List<Vuelo>();
            try
            {
                var urlApi = _configuration.GetSection("ENDPOINT_API").Value;
                var respuesta = await HttpHelper.Get($"{urlApi}{Enumerado.ApiVuelos}");
                if(respuesta != null)
                {
                    salida = JsonConvert.DeserializeObject<List<Vuelo>>(respuesta);
                }
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

            return StatusCode(statusCode, salida);
        }
    }
}
