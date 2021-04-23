using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaTecnicaCore.Entities
{
    [Table("ESTADOSVUELO")]
    public class EstadoVuelo : EntidadBase
    {
        [Required(AllowEmptyStrings = false)]
        public string Nombre { get; set; }
    }
}
