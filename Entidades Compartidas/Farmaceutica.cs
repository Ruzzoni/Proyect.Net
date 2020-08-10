using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Farmaceutica
    {
        private string Ruc;
        private string Nombre;
        private string Email;
        private string Direccion;

        public string _ruc
        {
            get { return Ruc; }
            set { Ruc = value; }
        }

        public string _nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string _email
        {
            get { return Email; }
            set { Email = value; }
        }

        public string _dir
        {
            get { return Direccion; }
            set { Direccion = value; }
        }

        public Farmaceutica(string nRuc, string nNombre, string nEmail, string nDir)
        {
            _ruc = nRuc;
            _nombre = nNombre;
            _email = nEmail;
            _dir = nDir;
        }
    }
}
