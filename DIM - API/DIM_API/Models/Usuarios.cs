using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIM_API.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaConfirmacionAlta { get; set; }
        public string Nombre { get; set; }
        public string TipoUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Int16 TipoDocumento { get; set; }
        public Decimal NumeroDocumento { get; set; }
        public string CodigoVerificacion { get; set; }
        public string Telefono { get; set; }
        public string ImagenDNI { get; set; }

    }
}
