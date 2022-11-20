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
    public class AudioLibroService : IAudioLibroService
    {

        AudioLibros _oAudioLibro = new AudioLibros();
        List<AudioLibros> _oAudioLibros = new List<AudioLibros>();

        public AudioLibros Add(AudioLibros oAudioLibros)
        {
            _oAudioLibro = new AudioLibros();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oEmpleados = con.Query<AudioLibros>("InsertAudioLibros", this.setParameters(oAudioLibros),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oAudioLibro.Error = ex.Message;
            }
            return _oAudioLibro;
        }

        public string Delete(int AudioLibroId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@IdAudioLibro", AudioLibroId);
                        con.Query("DeleteAudioLibros", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oAudioLibro.Error = ex.Message;
            }
            return _oAudioLibro.Error;
        }

        public AudioLibros Get(int AudioLibroId)
        {
            _oAudioLibro = new AudioLibros();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@IdAudioLibro", AudioLibroId); var oAudioLibros = con.Query<AudioLibros>("SelectIdAudioLibro", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oAudioLibros != null && oAudioLibros.Count() > 0)
                    {
                        _oAudioLibro = oAudioLibros.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oAudioLibro.Error = ex.Message;
            }
            return _oAudioLibro;
        }

        public List<AudioLibros> Gets()
        {
            _oAudioLibros = new List<AudioLibros>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oAudioLibros = con.Query<AudioLibros>("SelectIdAudioLibros", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oAudioLibros != null && oAudioLibros.Count() > 0)
                    {
                        _oAudioLibros = oAudioLibros;
                    }
                }
            }
            catch (Exception ex)
            {
                _oAudioLibro.Error = ex.Message;
            }
            return _oAudioLibros;
        }

        public AudioLibros Update(AudioLibros oAudioLibros)
        {
            _oAudioLibro = new AudioLibros();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oEmpleados = con.Query<AudioLibros>("UpdateAudioLibro", this.setParameters(oAudioLibros),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oAudioLibro.Error = ex.Message;
            }
            return _oAudioLibro;
        }

        private object setParameters(AudioLibros oAudioLibros)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oAudioLibros.IdAudioLibro != 0) parameters.Add("@IdAudioLibro", oAudioLibros.IdAudioLibro);
            parameters.Add("@Titilo", oAudioLibros.Titulo);
            parameters.Add("@Tipo", oAudioLibros.Tipo);
            parameters.Add("@Autor", oAudioLibros.Autor);
            parameters.Add("@Editorial", oAudioLibros.Editorial);
            parameters.Add("@Img", oAudioLibros.Img);
            return parameters;
        }
    }
}
