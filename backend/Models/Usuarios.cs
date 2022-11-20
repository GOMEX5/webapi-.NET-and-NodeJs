using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
       
        public string Nombre { get; set; }
        
        public string Apellido { get; set; }

        public string Tipo { get; set; }

        public string Correo { get; set; }
        
        public string Password { get; set; }
        
        public string Error { get; set; }
    }
}
