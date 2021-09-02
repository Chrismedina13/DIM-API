using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class MedicamentosMascotas
    {
        public Int64 MascotaID { get; set; }
        public string MedicamentID { get; set; }
        public decimal Dosis { get; set; }
        public DateTime Frecuencia { get; set; }
        public int? RenglonVisita { get; set; }



    }
}
