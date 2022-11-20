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
    public class PeriodicoService : IPeriodicoService
    {

        Periodicos _oPeriodico = new Periodicos();
        List<Periodicos> _oPeriodicos = new List<Periodicos>();

        public Periodicos Add(Periodicos oPeriodicos)
        {
            _oPeriodico = new Periodicos();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEmpleados = con.Query<Periodicos>("InsertPeriodicos", this.setParameters(oPeriodicos),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oPeriodico.Error = ex.Message;
            }
            return _oPeriodico;
        }

        public string Delete(int PeriodicoId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@IdPeriodico", PeriodicoId);
                        con.Query("DeletePeriodicos", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oPeriodico.Error = ex.Message;
            }
            return _oPeriodico.Error;
        }

        public Periodicos Get(int PeriodicoId)
        {
            _oPeriodico = new Periodicos();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@IdPeriodico", PeriodicoId); var oPeriodicos = con.Query<Periodicos>("SelectPeriodico", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oPeriodicos != null && oPeriodicos.Count() > 0)
                    {
                        _oPeriodico = oPeriodicos.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oPeriodico.Error = ex.Message;
            }
            return _oPeriodico;
        }

        public List<Periodicos> Gets()
        {
            _oPeriodicos = new List<Periodicos>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oPeriodicos = con.Query<Periodicos>("SelectPeriodicos", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oPeriodicos != null && oPeriodicos.Count() > 0)
                    {
                        _oPeriodicos = oPeriodicos;
                    }
                }
            }
            catch (Exception ex)
            {
                _oPeriodico.Error = ex.Message;
            }
            return _oPeriodicos;
        }

        public Periodicos Update(Periodicos oPeriodicos)
        {
            _oPeriodico = new Periodicos();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oEmpleados = con.Query<Periodicos>("UpdatePeriodico", this.setParameters(oPeriodicos),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oPeriodico.Error = ex.Message;
            }
            return _oPeriodico;
        }

        private object setParameters(Periodicos oPeriodicos)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oPeriodicos.IdPeriodico != 0) parameters.Add("@IdPeriodico", oPeriodicos.IdPeriodico);
            parameters.Add("@Nombre", oPeriodicos.Nombre);
            parameters.Add("@Tipo", oPeriodicos.Tipo);
            parameters.Add("@FechaEdicion", oPeriodicos.FechaEdicion);
            parameters.Add("@Numero", oPeriodicos.Numero);
            parameters.Add("@Img", oPeriodicos.Img);
            return parameters;
        }
    }
}
