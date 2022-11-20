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
    public class HistoriaService : IHistorialService
    {

        Historials _oHistorial = new Historials();
        List<Historials> _oHistorials = new List<Historials>();

        public Historials Add(Historials oHistorials)
        {
            _oHistorial = new Historials();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEmpleados = con.Query<Historials>("InsertHistorials", this.setParameters(oHistorials),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oHistorial.Error = ex.Message;
            }
            return _oHistorial;
        }

        public string Delete(int HistorialId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var param = new DynamicParameters();

                        param.Add("@IdHistorial", HistorialId);
                        con.Query("DeleteHistorials", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oHistorial.Error = ex.Message;
            }
            return _oHistorial.Error;
        }

        public Historials Get(int HistorialId)
        {
            _oHistorial = new Historials();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@IdHistorial", HistorialId); var oHistorials = con.Query<Historials>("SelectHistorial", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oHistorials != null && oHistorials.Count() > 0)
                    {
                        _oHistorial = oHistorials.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oHistorial.Error = ex.Message;
            }
            return _oHistorial;
        }

        public List<Historials> Gets()
        {
            _oHistorials = new List<Historials>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oHistorials = con.Query<Historials>("SelectHistorials", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oHistorials != null && oHistorials.Count() > 0)
                    {
                        _oHistorials = oHistorials;
                    }
                }
            }
            catch (Exception ex)
            {
                _oHistorial.Error = ex.Message;
            }
            return _oHistorials;
        }

        public Historials Update(Historials oHistorials)
        {
            _oHistorial = new Historials();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oEmpleados = con.Query<Historials>("UpdateHistorial", this.setParameters(oHistorials),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oHistorial.Error = ex.Message;
            }
            return _oHistorial;
        }

        private object setParameters(Historials oHistorials)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oHistorials.IdHistorial != 0) parameters.Add("@IdHistorial", oHistorials.IdHistorial);
            parameters.Add("@IdUsuario", oHistorials.IdUsuario);
            parameters.Add("@IdLibro", oHistorials.IdLibro);
            parameters.Add("@IdRevista", oHistorials.IdRevista);
            parameters.Add("@IdPeriodico", oHistorials.IdPeriodico);
            parameters.Add("@IdAudioLibro", oHistorials.IdAudioLibro);
            return parameters;
        }
    }
}
