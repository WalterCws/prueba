using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaTecnicaCore.Entities
{
    [Table("VUELOS")]
    public class Vuelo : EntidadBase
    {
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }

        [Required(AllowEmptyStrings = false)]
        public Ciudad CiudadDestino { get; set; }

        [Required(AllowEmptyStrings = false)]
        public Ciudad CiudadOrigen { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Range(1,Int32.MaxValue)]
        public int NumeroVuelo { get; set; }

        public Vuelo NuevoVuelo { get; set; }

        [Required(AllowEmptyStrings = false)]
        public EstadoVuelo Estado { get; set; }

        [Required(AllowEmptyStrings = false)]
        public Aerolinea Aerolinea { get; set; }
    }
}
