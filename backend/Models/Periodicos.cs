using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Periodicos
    {
        [Key]
        public int IdPeriodico { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string FechaEdicion { get; set; }

        public string Numero { get; set; }

        public string Img { get; set; }

        public string Error { get; set; }
    }
}