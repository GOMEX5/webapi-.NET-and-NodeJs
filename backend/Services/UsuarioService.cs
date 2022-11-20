using BackEnd.Conexion;
using BackEnd.IServices;
using BackEnd.Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace BackEnd.Services
{
    public class UsuarioService : IUsuarioService
    {

        Usuarios _oUsuario = new Usuarios();
        List<Usuarios> _oUsuarios = new List<Usuarios>();

        public Usuarios Add(Usuarios oUsuarios)
        {
            _oUsuario = new Usuarios();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oUsuario = con.Query<Usuarios>("InsertUsuarios", this.setParameters(oUsuarios),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario;
        }

        public string Delete(int UsuarioId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@IdUsuario", UsuarioId);
                        con.Query("DeleteUsuarios", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario.Error;
        }

        public Usuarios Get(int UsuarioId)
        {
            _oUsuario = new Usuarios();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@IdUsuario", UsuarioId); var oUsuarios = con.Query<Usuarios>("SelectUsuario", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oUsuarios != null && oUsuarios.Count() > 0)
                    {
                        _oUsuario = oUsuarios.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario;
        }

        public Usuarios GetCorreo(string Correo)
        {
            _oUsuario = new Usuarios();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    var oUsuarios = con.Query<Usuarios>("SelectUser", 
                    new {
                        Correo = Correo
                    },
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oUsuarios != null && oUsuarios.Count() > 0)
                    {
                        _oUsuario = oUsuarios.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario;
        }


        public List<Usuarios> Gets()
        {
            _oUsuarios = new List<Usuarios>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oUsuarios = con.Query<Usuarios>("SelectUsuarios", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oUsuarios != null && oUsuarios.Count() > 0)
                    {
                        _oUsuarios = oUsuarios;
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuarios;
        }


        public Usuarios Update(Usuarios oUsuarios)
        {
            _oUsuario = new Usuarios();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oEmpleados = con.Query<Usuarios>("UpdateUsuarios", this.setParameters(oUsuarios),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oUsuario.Error = ex.Message;
            }
            return _oUsuario;
        }

        private object setParameters(Usuarios oUsuarios)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oUsuarios.IdUsuario != 0) parameters.Add("@IdUsuario", oUsuarios.IdUsuario);
            parameters.Add("@Nombre", oUsuarios.Nombre);
            parameters.Add("@Apellido", oUsuarios.Apellido);
            parameters.Add("@Tipo", oUsuarios.Tipo);
            // if (oUsuarios.Correo != null) parameters.Add("@Correo", oUsuarios.Correo);
            parameters.Add("@Correo", oUsuarios.Correo);
            parameters.Add("@Password", oUsuarios.Password);
            return parameters;
        }
    }
}
