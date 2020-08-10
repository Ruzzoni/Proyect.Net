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
    public class PersistenciaEmpleado
    {
               public static void Agregar(Empleado E)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("AltaEmpleado", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Login", E._login.ToString());
            _Comando.Parameters.AddWithValue("@Contraseña", E._password.ToString());
            _Comando.Parameters.AddWithValue("@Nombre", E._nombre.ToString());
            _Comando.Parameters.AddWithValue("@Apellido", E._Apellido.ToString());
            _Comando.Parameters.AddWithValue("@HoraI", Convert.ToDateTime(E._horai.ToString()));
            _Comando.Parameters.AddWithValue("@HoraF", Convert.ToDateTime(E._horaf.ToString()));
            
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe empleado");
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

        public static void Modificar(Empleado E)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ModificarEmpleado", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Login", E._login.ToString());
            _Comando.Parameters.AddWithValue("@Contraseña", E._password.ToString());
            _Comando.Parameters.AddWithValue("@Nombre", E._nombre.ToString());
            _Comando.Parameters.AddWithValue("@Apellido", E._Apellido.ToString());
            _Comando.Parameters.AddWithValue("@HoraI", E._horai.ToString());
            _Comando.Parameters.AddWithValue("@HoraF", E._horaf.ToString());

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("no existe el usuario ");
                else if (oAfectados == -2)
                    throw new Exception(" no existe la farmaceutica");
                else if (oAfectados == -3)
                    throw new Exception(" no existe el epmleado");
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

        public static void Eliminar(Empleado E)
        {

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("BajaEmpleado", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Login", E._login.ToString());

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Error: Login incorecto");
                else if (oAfectados == -2)
                    throw new Exception("Error: el elpleado ya a sido eliminado");
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

        public static Empleado Buscar(String Login)
        {
            Empleado E = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("BuscarEmpleado ", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Login", Login.ToString());

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    E = new Empleado(_Reader["Login"].ToString(), _Reader["Contraseña"].ToString(), _Reader["Nombre"].ToString(), _Reader["Apellido"].ToString(), _Reader["Hora_I"].ToString(), _Reader["Hora_F"].ToString());

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

            return E;
        }


        public static Empleado LogueoEmpleado(String Login, string password)
        {
            Empleado E = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("LogueoEmpleado ", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Login", Login.ToString());
            _Comando.Parameters.AddWithValue("@Password", password.ToString());
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    E = new Empleado(_Reader["Login"].ToString(), _Reader["Contraseña"].ToString(), _Reader["Nombre"].ToString(), _Reader["Apellido"].ToString(), null, null);

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

            return E;
        }
    
    }
}
