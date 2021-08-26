using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Mascota
    {
        public long MascotaID { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public DateTime? FechaValidacion { get; set; }
        public string NroIdentificadorCriadero { get; set; }
        public string CodigoDeChip { get; set; }
        public string DIeta { get; set; }
        public string OtrosMedicamentos { get; set; }
        public string Pelaje { get; set; }
        public Int16 Sexo { get; set; }
        public Int16 CondicionDeSalud { get; set; }
        public string OtrosDatosDeSalud { get; set; }
        public int Edad { get; set; }
        public Int16 Tamanio { get; set; }
        public string Nombre { get; set; }
        public int UsuarioID { get; set; }
        public string Especie { get; set; }
        public string RazaID { get; set; }

    }
}
