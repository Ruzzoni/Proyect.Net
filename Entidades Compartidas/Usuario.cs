using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
     public abstract class Usuario
    {
        private String Login ;
        private String Password;
        private String Nombre;
        private String Apellido;


        public String _login
        {
            get { return Login; }
            set { Login = value; }
        }

        public String _password
        {
            get { return Password; }
            set
            {
             Password = value;
            }
        }

        public string _nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

          public string _Apellido
        {
            get { return Apellido; }
            set { Apellido = value; }
        }



        public Usuario(String nLogin, String nPassword, String nNombre, String nApellido)
        {
            _login = nLogin;
            _password = nPassword;
            _nombre = nNombre;
            _Apellido = nApellido;
        }

}

}


