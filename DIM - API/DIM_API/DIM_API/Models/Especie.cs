using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Especie
    {

        public string EspecieID { get; set; }
        public string RazaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
