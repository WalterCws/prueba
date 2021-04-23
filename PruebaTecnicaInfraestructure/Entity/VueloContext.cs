using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnicaInfraestructure.Entity
{
    public class VueloContext : DbContext
    {
        public VueloContext(DbContextOptions<VueloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vuelo> Vuelo { get;set;}
        public virtual DbSet<Aerolinea> Aerolinea { get; set; }
        public virtual DbSet<EstadoVuelo> EstadoVuelo { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }

    }
}
