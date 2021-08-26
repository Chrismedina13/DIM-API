using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DIM_API.Models;

namespace DIM_API.Data
{
    public class DIM_APIContext : DbContext
    {
        public DIM_APIContext (DbContextOptions<DIM_APIContext> options)
            : base(options)
        {
        }

        public DbSet<DIM_API.Models.Direccion> Direccion { get; set; }

        public DbSet<DIM_API.Models.Usuarios> Usuarios { get; set; }

        public DbSet<DIM_API.Models.Veterinario> Veterinario { get; set; }

        public DbSet<DIM_API.Models.Campania> Campania { get; set; }

        public DbSet<DIM_API.Models.Medicamento> Medicamento { get; set; }

        public DbSet<DIM_API.Models.Raza> Raza { get; set; }

        public DbSet<DIM_API.Models.Especie> Especie { get; set; }

        public DbSet<DIM_API.Models.Mascota> Mascota { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicamentosMascotas>().HasKey(ba => new { ba.MascotaID, ba.MedicamentID });
            modelBuilder.Entity<CampaniaMascota>().HasKey(ba => new { ba.MascotaID, ba.CampaniaID });
            modelBuilder.Entity<CampaniaRaza>().HasKey(ba => new { ba.CampaniaID, ba.RazaID });
            modelBuilder.Entity<VeterinarioMascota>().HasKey(ba => new { ba.MascotaID, ba.RenglonVisita });


        }

        public DbSet<DIM_API.Models.MedicamentosMascotas> MedicamentosMascotas { get; set; }

        public DbSet<DIM_API.Models.Fallecimiento> Fallecimiento { get; set; }

        public DbSet<DIM_API.Models.CampaniaMascota> CampaniaMascota { get; set; }

        public DbSet<DIM_API.Models.CampaniaRaza> CampaniaRaza { get; set; }

        public DbSet<DIM_API.Models.TipoVisita> TipoVisita { get; set; }

        public DbSet<DIM_API.Models.VeterinarioMascota> VeterinarioMascota { get; set; }



    }
}
