using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class VeterinarioMascota
    {
        public long MascotaID { get; set; }
        public int RenglonVisita { get; set; }
        public string TipoID { get; set; }
        public int VeterinarioID { get; set; }
    }
}
