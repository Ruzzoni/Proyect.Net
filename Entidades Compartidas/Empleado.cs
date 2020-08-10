using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Empleado:Usuario
    {
      
        private string HoraI;
        private string HoraF;


        public string _horai
        {
            get { return HoraI; }
            set { HoraI = value; }
        }

         public string _horaf
        {
            get { return HoraF; }
            set { HoraF = value; }
        }

         public Empleado(String nLogin, String nPassword, String nNombre, String nApellido, string nHoraI, string nHoraF)
             : base(nLogin, nPassword, nNombre, nApellido)
         {
             _horai = nHoraI;
             _horaf = nHoraF;
         }
    }
}
