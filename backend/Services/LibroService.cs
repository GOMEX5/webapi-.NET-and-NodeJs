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
    public class LibroService : ILibroService
    {

        Libros _oLibro = new Libros();
        List<Libros> _oLibros = new List<Libros>();

        public Libros Add(Libros oLibros)
        {
            _oLibro = new Libros();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEmpleados = con.Query<Libros>("InsertLibros", this.setParameters(oLibros),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oLibro.Error = ex.Message;
            }
            return _oLibro;
        }

        public string Delete(int LibroId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@IdLibro", LibroId);
                        con.Query("DeleteLibros", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oLibro.Error = ex.Message;
            }
            return _oLibro.Error;
        }

        public Libros Get(int LibroId)
        {
            _oLibro = new Libros();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@IdLibro", LibroId); var oLibros = con.Query<Libros>("SelectLibro", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oLibros != null && oLibros.Count() > 0)
                    {
                        _oLibro = oLibros.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oLibro.Error = ex.Message;
            }
            return _oLibro;
        }

        public List<Libros> Gets()
        {
            _oLibros = new List<Libros>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oLibros = con.Query<Libros>("SelectLibros", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oLibros != null && oLibros.Count() > 0)
                    {
                        _oLibros = oLibros;
                    }
                }
            }
            catch (Exception ex)
            {
                _oLibro.Error = ex.Message;
            }
            return _oLibros;
        }

        public Libros Update(Libros oLibros)
        {
            _oLibro = new Libros();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oEmpleados = con.Query<Libros>("UpdateLibros", this.setParameters(oLibros),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oLibro.Error = ex.Message;
            }
            return _oLibro;
        }

        private object setParameters(Libros oLibros)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oLibros.IdLibro != 0) parameters.Add("@IdLibro", oLibros.IdLibro);
            parameters.Add("@Titulo", oLibros.Titulo);
            parameters.Add("@Categoria", oLibros.Categoria);
            parameters.Add("@Autor", oLibros.Autor);
            parameters.Add("@Editorial", oLibros.Editorial);
            parameters.Add("@Img", oLibros.Img);
            return parameters;
        }
    }
}
