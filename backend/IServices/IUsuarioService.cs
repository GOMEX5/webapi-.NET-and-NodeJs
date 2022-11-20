using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd.IServices
{
    public interface IUsuarioService
    {
        Usuarios Add(Usuarios oUsuarios);
        
        List<Usuarios> Gets();

        Usuarios Get(int UsuarioId);

       Usuarios GetCorreo(string Correo);

        string Delete(int UsuarioId);

        Usuarios Update(Usuarios oUsuarios);
    }
}
