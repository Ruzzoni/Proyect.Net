using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

namespace ProyectoFinalBios
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {

            if (TxbLogin.Text == null)
                LblError.Text = "Error debe ingresar un nombre de usuario";

            if (TxbPassword.Text == null)
                LblError.Text = "Error debe ingresar un password valido";

            try
            {
                
                Entidades_Compartidas.Usuario unUsu = LogicaUsuario.Logueo(TxbLogin.Text, TxbPassword.Text);
                if (unUsu != null)
                {
                    Session["Usuario"] = unUsu;
                    Response.Redirect("Principal.aspx");
                }
                else
                    LblError.Text = "Datos Incorrectos";
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
 
        }
    }
}