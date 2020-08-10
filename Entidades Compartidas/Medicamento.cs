using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Medicamento
    {
        Farmaceutica Farm;
        private int codigo;
        private string Nombre;
        private int precio;
        private string Descripcion;

        public int _codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public Farmaceutica _Farm
        {
            set
            {
                if (value == null)
                    throw new Exception("se debe saber la farmaceitica para la que tabaja el empleado");
                else
                    Farm = value;
            }
            get { return Farm; }

        }

        public string _nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public int _precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string _desc
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public Medicamento(Farmaceutica nFar,int nCodigo, string nNombre, int nPrecio, string nDesc)
        {
            _Farm = nFar;
            _codigo = nCodigo;
            _nombre = nNombre;
            _precio = nPrecio;
            _desc = nDesc;
        }
    }
}
