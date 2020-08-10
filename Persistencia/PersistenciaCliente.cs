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
    public class PersistenciaCliente
    {
        public static List<long> BuscarTelefonos(string Login)
        {

            SqlConnection _conexion = new SqlConnection(Conexion._Cnn);
            SqlDataReader _Reader;
            List<long> _Telefonos = new List<long>();
            SqlCommand _Comando = new SqlCommand("ListarTelefono", _conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("@Login", Login.ToString());


            try
            {
                _conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    _Telefonos.Add(Convert.ToInt64(_Reader.GetInt32(0)));
                }

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _conexion.Close();
            }

            return _Telefonos;

        }

        public static void AgregarTelefono(string Login, int numero)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("AltaTelefono ", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("@Login", Login.ToString());
            _Comando.Parameters.AddWithValue("@Numero", numero.ToString());

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya Existe el telefono");
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

        public static void EliminarTelefono(string Login, int numero)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("BajaTelefono ", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("@Login", Login.ToString());
            _Comando.Parameters.AddWithValue("@Numero", numero);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("no existe este telefono");
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

        public static void Agregar(Cliente C)
        {
            Int64 numero = C.Telefonos.ElementAt(0);
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("AltaCliente", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Login", C._login.ToString());
            _Comando.Parameters.AddWithValue("@Contraseña", C._password.ToString());
            _Comando.Parameters.AddWithValue("@Nombre", C._nombre.ToString());
            _Comando.Parameters.AddWithValue("@Apellido", C._Apellido.ToString());
            _Comando.Parameters.AddWithValue("@Direccion", C._Dir.ToString());

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya Existe el cliente");
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

        public static void Modificar(Cliente C)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ModificarCliente", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Login", C._login.ToString());
            _Comando.Parameters.AddWithValue("@Contraseña", C._password.ToString());
            _Comando.Parameters.AddWithValue("@Nombre", C._nombre.ToString());
            _Comando.Parameters.AddWithValue("@Apellido", C._Apellido.ToString());
            _Comando.Parameters.AddWithValue("@Direccion", C._Dir.ToString());

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Error: no existe el usario ");
                else if (oAfectados == -2)
                    throw new Exception("Error: no existe el cliente");
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


        public static Cliente Buscar(String Login)
        {
            Cliente C = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("Exec BuscarCliente " + Login.ToString(), _Conexion);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    C = new Cliente(_Reader["Login"].ToString(), _Reader["Contraseña"].ToString(), _Reader["Nombre"].ToString(), _Reader["Apellido"].ToString(), _Reader["Direccion"].ToString(), null);

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

            return C;
        }

        public static Cliente LogueoCliente(string login, string password)
        {
            Cliente C = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("LogueoCliente", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@Login", login.ToString());
            _Comando.Parameters.AddWithValue("@Password", password.ToString());

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    C = new Cliente(_Reader["Login"].ToString(), _Reader["Contraseña"].ToString(), _Reader["Nombre"].ToString(), _Reader["Apellido"].ToString(),null, null);

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

            return C;
        }

    }
}
