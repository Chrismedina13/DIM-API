using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Vacunacion
    {
        public long MascotaID { get; set; }
        public int RenglonVacuna { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public DateTime? FechaRevacunacion { get; set; }
        public string CodigoSENASA { get; set; }
        public string Lote { get; set; }
        public string Serie { get; set; }
        public string Dosis { get; set; }
        public int VacunaID { get; set; }


    }
}
