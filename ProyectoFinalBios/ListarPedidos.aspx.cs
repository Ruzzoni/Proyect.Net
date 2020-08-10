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
    public partial class ListarPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Session["Usuario"] is Entidades_Compartidas.Usuario))
                    Response.Redirect("Default.aspx");

                Cliente C = (Cliente)Session["Usuario"];

                if (!IsPostBack)
                {
                    GridView1.DataSource = LogicaPedido.ListarPorCliente(C);
                    GridView1.DataBind();
                }

            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
            
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            Pedido p = LogicaPedido.Buscar(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text.ToString().Trim()));
            LogicaPedido.Eliminar(p);
        }
    }
}