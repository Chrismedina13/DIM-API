using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Veterinario
    {
        [Key]
        public int VeterinarioID { get; set; }
        public Decimal NumeroMatricula { get; set; }
        public DateTime? FechaVerificacionMatricula { get; set; }
    }
}
