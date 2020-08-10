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
    public partial class MP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Session["Usuario"] is Entidades_Compartidas.Usuario))
                    Response.Redirect("Default.aspx");

                if (Session["Usuario"] is Entidades_Compartidas.Cliente)
                {
                    Lblusuario.Text = "Cliente";
                    Menu1.Items[0].Enabled = false;
                    Menu1.Items[0].Selectable = false;
                    Menu1.Items[3].Enabled = false;
                    Menu1.Items[3].Selectable = false;
                    Menu1.Items[5].Enabled = false;
                    Menu1.Items[5].Selectable = false;


                }
                else if (Session["Usuario"] is Entidades_Compartidas.Empleado)
                {
                    Lblusuario.Text = "Empleado";
                    Menu1.Items[2].Enabled = false;
                    Menu1.Items[2].Selectable = false;
                    Menu1.Items[6].Enabled = false;
                    Menu1.Items[6].Selectable = false;
                }


            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}