using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Campania
    {
        public Int64 CampaniaID { get; set; }
        public decimal CuposDisponibles { get; set; }
        public string Descripcion { get; set; }
        public Int16 Tipo { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public int UsuarioID { get; set; }

    }
}
