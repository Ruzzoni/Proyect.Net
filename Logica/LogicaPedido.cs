using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    public class LogicaPedido
    {
        public static void Agregar(Pedido P)
        {
            PersistenciaPedido.Agregar(P);
        }

        public static void Modificar(Pedido P)
        {
            PersistenciaPedido.Modificar(P);
        }

        public static void Eliminar(Pedido P)
        {
            PersistenciaPedido.Eliminar(P);
        }

        public static Pedido Buscar(int Numero)
        {
            return PersistenciaPedido.Buscar(Numero);
        }

        public static List<Pedido> ListarPorCliente(Cliente C)
        {
            return PersistenciaPedido.ListarPorClinte(C);
        }

        public static List<Pedido> ListarPorMedicamento(Medicamento M)
        {
            return PersistenciaPedido.ListarPorMedicamento(M);
        }

        public static List<Pedido> ListarPorMedicamentoGenerado(Medicamento M)
        {
            return PersistenciaPedido.ListarPorMedicamentoGenerado(M);
        }
        public static List<Pedido> ListarPorMedicamentoEntregado(Medicamento M)
        {
            return PersistenciaPedido.ListarPorMedicamentoEntregado(M);
        }
        public static List<Pedido> ListarPedidoGenerado(string login)
        {
            return PersistenciaPedido.ListarPedidosGenerados(login);
        }

    }
}
