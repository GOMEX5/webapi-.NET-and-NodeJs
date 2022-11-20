using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd.IServices
{
    public interface ILibroService
    {
        Libros Add(Libros oLibros);

        List<Libros> Gets();

        Libros Get(int LibroId);

        string Delete(int LibroId);

        Libros Update(Libros oLibros);
    }
}
