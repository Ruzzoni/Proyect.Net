using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Cliente:Usuario
    {
        private String Direccion;
        private List<long> telefonos;

        public String _Dir
        {
            get { return Direccion; }
            set
            {
             Direccion= value;
            }
        }

        public List<long> Telefonos
        {
            get { return telefonos; }
            set { telefonos = value; }
        }

        public Cliente(String nLogin, String nPassword, String nNombre, String nApellido, String Dir, List<long> nTelefonos)
            : base(nLogin, nPassword, nNombre, nApellido)
        {
            _Dir = Dir;
            Telefonos = nTelefonos;
        }
    }
}
