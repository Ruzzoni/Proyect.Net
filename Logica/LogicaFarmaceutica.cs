using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    public class LogicaFarmaceutica
    {
        public static void Alta(Farmaceutica F)
        {
            PersistenciaFarmaceutica.Agregar(F);
        }

        public static void Baja(Farmaceutica F)
        {
            PersistenciaFarmaceutica.Eliminar(F);
        }

        public static void Modificar(Farmaceutica F)
        {
            PersistenciaFarmaceutica.Modificar(F);
        }

        public static Farmaceutica Buscar(string Ruc)
        {
            return PersistenciaFarmaceutica.Buscar(Ruc);
        }

        public static List<Farmaceutica> Listar()
        {
            return PersistenciaFarmaceutica.Listar();
        }
    }
}
