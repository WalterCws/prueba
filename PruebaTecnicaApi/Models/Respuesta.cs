using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaApi.Models
{
    public class Respuesta
    {
        public string Mensaje { get; set; } = Mensajes.Ok;

        public object Data { get; set; }
    }
}
