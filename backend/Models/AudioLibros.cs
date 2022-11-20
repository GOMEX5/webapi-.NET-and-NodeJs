using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class AudioLibros
    {
        [Key]
        public int IdAudioLibro { get; set; }

        public string Titulo { get; set; }

        public string Tipo { get; set; }

        public string Autor { get; set; }

        public string Editorial { get; set; }

        public string Img { get; set; }

        public string Error { get; set; }
    }
}
