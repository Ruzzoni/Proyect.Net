using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using Entidades_Compartidas;

namespace Persistencia
{
    public class PersistenciaMedicamento
    {
        public static void Agregar(Medicamento M)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("AltaMedicamento", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@RUC", M._Farm._ruc);
            _Comando.Parameters.AddWithValue("@Nombre", M._nombre);
            _Comando.Parameters.AddWithValue("@Precio", M._precio);
            _Comando.Parameters.AddWithValue("@Descripcion", M._desc);


            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe ese medicamento");
                else if (oAfectados == -2)
                    throw new Exception("Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }

        public static void Modificar(Medicamento M)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ModificarMedicamento", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@RUC", M._Farm._ruc);
            _Comando.Parameters.AddWithValue("@Codigo", M._codigo);
            _Comando.Parameters.AddWithValue("@Nombre", M._nombre);
            _Comando.Parameters.AddWithValue("@Precio", M._precio);
            _Comando.Parameters.AddWithValue("@Descripcion", M._desc);



            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("no existe esa farmaceutica ");
                else if (oAfectados == -2)
                    throw new Exception(" no existe ese medicamento");
                else if (oAfectados == -3)
                    throw new Exception(" error");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }

        public static void Eliminar(Medicamento M)
        {

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("BajaMedicamento", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@RUC", M._Farm._ruc);
            _Comando.Parameters.AddWithValue("@Codigo", M._codigo);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Error: no existe esa farmaceutica");
                else if (oAfectados == -2)
                    throw new Exception("Error: no existe ese medicamento");
                else if (oAfectados == -3)
                    throw new Exception("Error");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }

        public static Medicamento Buscar(string Ruc, int codigo)
        {
            Medicamento M = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("Exec BuscarMedicamento " + Ruc + ", " +  codigo, _Conexion);


            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    M = new Medicamento(PersistenciaFarmaceutica.Buscar(_Reader["RUC"].ToString()), Convert.ToInt32(_Reader["Codigo"].ToString()), _Reader["Nombre"].ToString(), Convert.ToInt32(_Reader["Precio"].ToString()), _Reader["Descripcion"].ToString());

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return M;
        }

        public static List<Medicamento> ListarPorFarmaceutica(Farmaceutica F)
        {
            List<Medicamento> _lista = new List<Medicamento>(); ;
            SqlDataReader _Reader;


            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ListarMedicamentoPorFarmaceutica", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@RUC", F._ruc.ToString().Trim());

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                
                    while (_Reader.Read())
                    {
                        Medicamento M = new Medicamento(PersistenciaFarmaceutica.Buscar(_Reader["RUC"].ToString()), Convert.ToInt32(_Reader["Codigo"].ToString()), _Reader["Nombre"].ToString(), Convert.ToInt32(_Reader["Precio"].ToString()), _Reader["Descripcion"].ToString());
                        _lista.Add(M);
                    }
                

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return _lista;
        }

        public static List<Medicamento> Listar()
        {
            List<Medicamento> _lista = new List<Medicamento>(); ;
            SqlDataReader _Reader;


            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ListarMedicamento" , _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Medicamento M = new Medicamento(PersistenciaFarmaceutica.Buscar(_Reader["RUC"].ToString()), Convert.ToInt32(_Reader["Codigo"].ToString()), _Reader["Nombre"].ToString(), Convert.ToInt32(_Reader["Precio"].ToString()), _Reader["Descripcion"].ToString());
                        _lista.Add(M);
                    }
                }

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return _lista;
        }
    }
}
