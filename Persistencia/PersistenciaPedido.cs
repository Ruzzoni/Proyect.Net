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
    public class PersistenciaPedido
    {
            public static void Agregar(Pedido p)
            {
                SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
                SqlCommand _Comando = new SqlCommand("AltaPedido", _Conexion);
                _Comando.CommandType = CommandType.StoredProcedure;

                _Comando.Parameters.AddWithValue("@Ruc", p._med._Farm._ruc);
                _Comando.Parameters.AddWithValue("@Codigo", p._med._codigo);
                _Comando.Parameters.AddWithValue("@Login", p._Clie._login);
                _Comando.Parameters.AddWithValue("@Cantidad", p._cantidad);
                _Comando.Parameters.AddWithValue("@Estado", p._estado);


                SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
                _Retorno.Direction = ParameterDirection.ReturnValue;
                _Comando.Parameters.Add(_Retorno);

                try
                {
                    _Conexion.Open();
                    _Comando.ExecuteNonQuery();

                    int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                    if (oAfectados == -1)
                        throw new Exception("no existe el cliente");
                    else if (oAfectados == -2)
                        throw new Exception("no existe el medicamento");
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

            public static void Modificar(Pedido p)
            {
                SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
                SqlCommand _Comando = new SqlCommand("ModificarPedido", _Conexion);
                _Comando.CommandType = CommandType.StoredProcedure;

                _Comando.Parameters.AddWithValue("@Numero", p._numero);
                _Comando.Parameters.AddWithValue("@RUC", p._med._Farm._ruc);
                _Comando.Parameters.AddWithValue("@Codigo", p._med._codigo);
                _Comando.Parameters.AddWithValue("@Login", p._Clie._login);
                _Comando.Parameters.AddWithValue("@Estado", p._estado);



                SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
                _Retorno.Direction = ParameterDirection.ReturnValue;
                _Comando.Parameters.Add(_Retorno);

                try
                {
                    _Conexion.Open();
                    _Comando.ExecuteNonQuery();

                    int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                    if (oAfectados == -1)
                        throw new Exception("no existe Ese pedido ");
                    else if (oAfectados == -2)
                        throw new Exception(" no existe ese cliente");
                    else if (oAfectados == -3)
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

            public static void Eliminar(Pedido P)
            {

                SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
                SqlCommand _Comando = new SqlCommand("BajaPedido", _Conexion);
                _Comando.CommandType = CommandType.StoredProcedure;

                _Comando.Parameters.AddWithValue("@Numero", P._numero);

                SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
                _Retorno.Direction = ParameterDirection.ReturnValue;

                _Comando.Parameters.Add(_Retorno);

                try
                {
                    _Conexion.Open();
                    _Comando.ExecuteNonQuery();

                    int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                    if (oAfectados == -1)
                        throw new Exception("Error: no existe ese pedido ");
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

            public static Pedido Buscar(int numero)
            {
                Pedido P = null;
                SqlDataReader _Reader;

                SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
                SqlCommand _Comando = new SqlCommand("Exec BuscarPedido " + numero, _Conexion);

                try
                {
                    _Conexion.Open();
                    _Reader = _Comando.ExecuteReader();

                    if (_Reader.Read())
                        P = new Pedido(Convert.ToInt32(_Reader["Num_Pedido"].ToString()), PersistenciaMedicamento.Buscar((_Reader["RUC"].ToString()),Convert.ToInt32(_Reader["Codigo"].ToString())),PersistenciaCliente.Buscar(_Reader["Login"].ToString()), Convert.ToInt32(_Reader["Cantidad"].ToString()), _Reader["Estado"].ToString());

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

                return P;
            }

            public static List<Pedido> ListarPedidosGenerados(string login)
            {
                List<Pedido> _lista = new List<Pedido>(); ;
                SqlDataReader _Reader;


                SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
                SqlCommand _Comando = new SqlCommand("ListarPedidoGenerado" , _Conexion);
                _Comando.CommandType = CommandType.StoredProcedure;
                _Comando.Parameters.AddWithValue("@Login", login);

                try
                {
                    _Conexion.Open();
                    _Reader = _Comando.ExecuteReader();

                    if (_Reader.HasRows)
                    {
                        while (_Reader.Read())
                        {
                            Pedido P = new Pedido(Convert.ToInt32(_Reader["Num_Pedido"].ToString()), PersistenciaMedicamento.Buscar(_Reader["RUC"].ToString(), Convert.ToInt32(_Reader["Codigo"].ToString())), PersistenciaCliente.Buscar(_Reader["Login"].ToString()), Convert.ToInt32(_Reader["Cantidad"].ToString()), _Reader["Estado"].ToString());
                            _lista.Add(P);
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

            public static List<Pedido> ListarPorClinte(Cliente C)
            {
                List<Pedido> _lista = new List<Pedido>(); ;
                SqlDataReader _Reader;


                SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
                SqlCommand _Comando = new SqlCommand("ListarPedidoPorCliente " + C._login , _Conexion);
                _Comando.CommandType = CommandType.StoredProcedure;

                try
                {
                    _Conexion.Open();
                    _Reader = _Comando.ExecuteReader();

                    if (_Reader.HasRows)
                    {
                        while (_Reader.Read())
                        {
                             Pedido P = new Pedido(Convert.ToInt32(_Reader["Num_Pedido"].ToString()), PersistenciaMedicamento.Buscar((_Reader["RUC"].ToString()),Convert.ToInt32(_Reader["Codigo"].ToString())),PersistenciaCliente.Buscar(_Reader["Login"].ToString()), Convert.ToInt32(_Reader["Cantidad"].ToString()), _Reader["Estado"].ToString());
                            _lista.Add(P);
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

            public static List<Pedido> ListarPorMedicamento(Medicamento M)
            {
                List<Pedido> _lista = new List<Pedido>(); ;
                SqlDataReader _Reader;


                SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
                SqlCommand _Comando = new SqlCommand("ListarPedidoPorMedicamento" + M._Farm._ruc + ", " + M._codigo, _Conexion);
                _Comando.CommandType = CommandType.StoredProcedure;

                try
                {
                    _Conexion.Open();
                    _Reader = _Comando.ExecuteReader();

                    if (_Reader.HasRows)
                    {
                        while (_Reader.Read())
                        {
                            Pedido P = new Pedido(Convert.ToInt32(_Reader["Num_Pedido"].ToString()), PersistenciaMedicamento.Buscar((_Reader["RUC"].ToString()), Convert.ToInt32(_Reader["Codigo"].ToString())), PersistenciaCliente.Buscar(_Reader["Login"].ToString()), Convert.ToInt32(_Reader["Cantidad"].ToString()), _Reader["Estado"].ToString());
                            _lista.Add(P);
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

            public static List<Pedido> ListarPorMedicamentoGenerado (Medicamento M)
            {
                List<Pedido> _lista = new List<Pedido>(); ;
                SqlDataReader _Reader;


                SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
                SqlCommand _Comando = new SqlCommand("ListarPedidoPorMedicamentoGenerado" + M._Farm._ruc + ", " + M._codigo, _Conexion);
                _Comando.CommandType = CommandType.StoredProcedure;

                try
                {
                    _Conexion.Open();
                    _Reader = _Comando.ExecuteReader();

                    if (_Reader.HasRows)
                    {
                        while (_Reader.Read())
                        {
                            Pedido P = new Pedido(Convert.ToInt32(_Reader["Num_Pedido"].ToString()), PersistenciaMedicamento.Buscar((_Reader["RUC"].ToString()), Convert.ToInt32(_Reader["Codigo"].ToString())), PersistenciaCliente.Buscar(_Reader["Login"].ToString()), Convert.ToInt32(_Reader["Cantidad"].ToString()), _Reader["Estado"].ToString());
                            _lista.Add(P);
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
            public static List<Pedido> ListarPorMedicamentoEntregado (Medicamento M)
            {
                List<Pedido> _lista = new List<Pedido>(); ;
                SqlDataReader _Reader;


                SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
                SqlCommand _Comando = new SqlCommand("ListarPedidoPorMedicamentoEntregado" + M._Farm._ruc + ", " + M._codigo, _Conexion);
                _Comando.CommandType = CommandType.StoredProcedure;

                try
                {
                    _Conexion.Open();
                    _Reader = _Comando.ExecuteReader();

                    if (_Reader.HasRows)
                    {
                        while (_Reader.Read())
                        {
                            Pedido P = new Pedido(Convert.ToInt32(_Reader["Num_Pedido"].ToString()), PersistenciaMedicamento.Buscar((_Reader["RUC"].ToString()), Convert.ToInt32(_Reader["Codigo"].ToString())), PersistenciaCliente.Buscar(_Reader["Login"].ToString()), Convert.ToInt32(_Reader["Cantidad"].ToString()), _Reader["Estado"].ToString());
                            _lista.Add(P);
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
