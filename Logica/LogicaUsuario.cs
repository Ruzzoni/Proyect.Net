using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    public class LogicaUsuario
    {
        public static void AgregarTelefono(string login, int numero)
        {
            PersistenciaCliente.AgregarTelefono(login, numero);
        }

        public static void EliminarTelefono(string login, int numero)
        {
            PersistenciaCliente.EliminarTelefono(login, numero);
        }


        public static void Agregar(Usuario U)
        {
            if (U is Empleado)
                PersistenciaEmpleado.Agregar((Empleado)U);
            else if (U is Cliente)
                PersistenciaCliente.Agregar((Cliente)U);
            else if (U == null)
                throw new Exception("Error no hay usuario para agregar");
        }

        public static void Modificar(Usuario U)
        {
            if (U is Empleado)
                PersistenciaEmpleado.Modificar((Empleado)U);
            else if (U is Cliente)
                PersistenciaCliente.Modificar((Cliente)U);
            else if (U == null)
                throw new Exception("Error no hay usuario para modificar");
        }

        public static void Eliminar(Usuario U)
        {
            if (U is Empleado)
                PersistenciaEmpleado.Eliminar((Empleado)U);
            else if (U is Cliente)
                throw new Exception("Error no se puede eliminar un cliente");
            else if (U == null)
                throw new Exception("Error no hay usuario para eliminar");
        }


        public static Entidades_Compartidas.Usuario BuscarCliente(String Login)
        {
            return PersistenciaCliente.Buscar(Login);
        }

        public static Entidades_Compartidas.Usuario BuscarEmpleado(String Login)
        {
            return PersistenciaEmpleado.Buscar(Login);
        }

        public static Usuario Logueo(string login, string password)
        {
             Usuario U = null;

             U = PersistenciaCliente.LogueoCliente(login,password);

            if (U == null)
                U = PersistenciaEmpleado.LogueoEmpleado(login,password);

            if (U == null)
                throw new Exception("usuario incorrecto");

            return U;
        }

        public static List<long> BuscarTelefonos(String Login)
        {
            return PersistenciaCliente.BuscarTelefonos(Login);
        }

    }
}
