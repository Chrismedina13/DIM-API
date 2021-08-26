using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class TipoVisita
    {
        [Key]
        public string TipoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
