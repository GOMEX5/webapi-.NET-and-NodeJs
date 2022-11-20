using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Libros
    {
        [Key]
        public int IdLibro { get; set; }

        public string Titulo { get; set; }

        public string Categoria { get; set; }

        public string Autor { get; set; }

        public string Editorial { get; set; }

        public string Img { get; set; }

        public string Error { get; set; }
    }
}
