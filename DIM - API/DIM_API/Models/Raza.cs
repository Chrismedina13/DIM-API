using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Raza
    {
        public string RazaID { get; set; }
        public string Descripcion { get; set; }
        public byte EsRazaPeligrosa { get; set; }
        public string EspecieID { get; set; }
    }
}
