using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Fallecimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MascotaID { get; set; }
        public string Lugar { get; set; }
        public string EspecificacionRiesgoEpidemiologico { get; set; }
        public DateTime Fecha { get; set; }
        public string Causa { get; set; }
        public byte RiesgoEpidemiologico { get; set; }

    }
}
