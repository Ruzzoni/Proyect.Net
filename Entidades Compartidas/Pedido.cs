using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Pedido
    {
        private int Numero;
        private int Cantidad;
        private string Estado;
        Medicamento Med;
        Cliente clie;

        public Medicamento _med
        {
            set
            {
                if (value == null)
                    throw new Exception("se debe seleccionar un medicamento");
                else
                    Med = value;
            }
            get { return Med; }

        }

        public Cliente _Clie
        {
            set
            {
                if (value == null)
                    throw new Exception("se debe tener un cliente para realizar un pedido");
                else
                    clie = value;
            }
            get { return clie; }

        }

        public int _numero
        {
            get { return Numero; }
            set { Numero = value; }
        }
        public int _cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        public string _estado
        {
            get { return Estado; }
            set { Estado = value; }
        }

        public Pedido(int nNumero, Medicamento nMed, Cliente nClie, int nCantidad, string nEstado)
        {
            _numero = nNumero;
            _med = nMed;
            _Clie = nClie;
            _cantidad = nCantidad;
            _estado = nEstado;
        }
    }
}
