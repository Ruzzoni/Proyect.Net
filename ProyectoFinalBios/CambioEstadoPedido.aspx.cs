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
    public partial class CambioEstadoPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario U = (Usuario)Session["Usuario"];
                GridView1.DataSource = LogicaPedido.ListarPedidoGenerado(U._login);
                GridView1.DataBind();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario U = (Usuario)Session["Usuario"];
            int numero = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text.ToString().Trim());
            Pedido P = LogicaPedido.Buscar(numero);
            if (P._estado == "Generado")
                P._estado = "Enviado";
            else if (P._estado == "Enviado")
                P._estado = "Entregado";
            LogicaPedido.Modificar(P);
            GridView1.DataSource = LogicaPedido.ListarPedidoGenerado(U._login);
            GridView1.DataBind();
        }
    }
}