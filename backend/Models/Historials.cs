using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Historials
    {
        [Key]
        public int IdHistorial { get; set; }

        public int IdUsuario { get; set; }

        public int IdLibro { get; set; }

        public int IdRevista { get; set; }

        public int IdPeriodico { get; set; }

        public int IdAudioLibro { get; set; }

        public DateTime Fecha { get; set;}

        public string Error { get; set; }
    }
}
