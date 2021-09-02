using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Direccion
    {
        public long DireccionID { get; set; }
        public string Calle { get; set; }
        public decimal Numero { get; set; }
        public decimal? Piso { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public Int64? CampaniaID { get; set; }
        public int? UsuarioID { get; set; }
        public long? MascotaID { get; set; }

    }
}
