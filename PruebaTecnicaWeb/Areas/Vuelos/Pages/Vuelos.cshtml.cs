using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaTecnicaCore.Entities;

namespace PruebaTecnicaWeb.Areas.Vuelos.Pages
{
    public class VuelosModel : PageModel
    {
        public void OnGet()
        {
        }

        [HttpGet]
        public IActionResult OnGetVuelos()
        {
            var vuelos = new List<Vuelo>();
            vuelos.Add(new Vuelo
            {
                NumeroVuelo = 1,
                Id = 1
            });

            return new JsonResult(vuelos);
        }
    }
}
