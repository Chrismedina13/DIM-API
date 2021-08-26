using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Medicamento
    {
        public string MedicamentoID { get; set; }
        public string Descripcion { get; set; }
        public byte Utilizable { get; set; }
    }
}
