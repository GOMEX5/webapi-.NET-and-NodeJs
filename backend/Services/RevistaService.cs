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
    public class RevistaService : IRevistaService
    {

        Revistas _oRevista = new Revistas();
        List<Revistas> _oRevistas = new List<Revistas>();

        public Revistas Add(Revistas oRevistas)
        {
            _oRevista = new Revistas();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEmpleados = con.Query<Revistas>("InsertRevistas", this.setParameters(oRevistas),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oRevista.Error = ex.Message;
            }
            return _oRevista;
        }

        public string Delete(int RevistaId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@IdRevista", RevistaId);
                        con.Query("DeleteRevistas", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oRevista.Error = ex.Message;
            }
            return _oRevista.Error;
        }

        public Revistas Get(int RevistaId)
        {
            _oRevista = new Revistas();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@IdRevista", RevistaId); var oRevistas = con.Query<Revistas>("SelectRevista", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oRevistas != null && oRevistas.Count() > 0)
                    {
                        _oRevista = oRevistas.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oRevista.Error = ex.Message;
            }
            return _oRevista;
        }

        public List<Revistas> Gets()
        {
            _oRevistas = new List<Revistas>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oRevistas = con.Query<Revistas>("SelectRevistas", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oRevistas != null && oRevistas.Count() > 0)
                    {
                        _oRevistas = oRevistas;
                    }
                }
            }
            catch (Exception ex)
            {
                _oRevista.Error = ex.Message;
            }
            return _oRevistas;
        }

        public Revistas Update(Revistas oRevistas)
        {
            _oRevista = new Revistas();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oEmpleados = con.Query<Revistas>("UpdateRevistas", this.setParameters(oRevistas),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oRevista.Error = ex.Message;
            }
            return _oRevista;
        }

        private object setParameters(Revistas oRevistas)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oRevistas.IdRevista != 0) parameters.Add("@IdRevista", oRevistas.IdRevista);
            parameters.Add("@Titulo", oRevistas.Titulo);
            parameters.Add("@Autor", oRevistas.Autor);
            parameters.Add("@FechaPublicacion", oRevistas.FechaPublicacion);
            parameters.Add("@Img", oRevistas.Img);
            return parameters;
        }
    }
}