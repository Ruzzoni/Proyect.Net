using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    public class LogicaMedicamento
    {
        public static void Alta(Medicamento M)
        {
            PersistenciaMedicamento.Agregar(M);
        }

        public static void Modificar(Medicamento M)
        {
            PersistenciaMedicamento.Modificar(M);
        }

        public static void Eliminar(Medicamento M)
        {
            PersistenciaMedicamento.Eliminar(M);
        }

        public static Medicamento Buscar(string ruc, int codigo)
        {
            return PersistenciaMedicamento.Buscar(ruc, codigo);
        }

        public static List<Medicamento> ListarPorFarmaceutica(Farmaceutica F)
        {
            return PersistenciaMedicamento.ListarPorFarmaceutica(F);
        }

        public static List<Medicamento> Listar()
        {
            return PersistenciaMedicamento.Listar();
        }
        
    }
}
