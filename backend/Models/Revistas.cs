using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Revistas
    {
        [Key]
        public int IdRevista { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string FechaPublicacion { get; set; }

        public string Img { get; set; }

        public string Error { get; set; }
    }
}
