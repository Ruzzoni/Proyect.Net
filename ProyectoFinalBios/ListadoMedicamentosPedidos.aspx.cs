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
    public partial class ListadoMedicamentosPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DdlRuc.DataSource = LogicaFarmaceutica.Listar();
                DdlRuc.DataTextField = "_ruc";
                DdlRuc.DataValueField = "_ruc";
                DdlRuc.DataBind();
                DdlFiltrar.Enabled = false;
                DdlFiltrar.Visible = false;
            }
        }

        protected void DdlRuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Farmaceutica F = LogicaFarmaceutica.Buscar(DdlRuc.SelectedValue.ToString().Trim());
            GridView1.DataSource = LogicaMedicamento.ListarPorFarmaceutica(F);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Medicamento M = LogicaMedicamento.Buscar(GridView1.SelectedRow.Cells[1].Text.ToString().Trim(), Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text.ToString().Trim()));
            GridView1.DataSource = LogicaPedido.ListarPorMedicamento(M);
            GridView1.DataBind();
            DdlFiltrar.Enabled = true;
            DdlFiltrar.Visible = true;
        }

        protected void DdlFiltrar_TextChanged(object sender, EventArgs e)
        {
            Medicamento M = LogicaMedicamento.Buscar(GridView1.SelectedRow.Cells[1].Text.ToString().Trim(), Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text.ToString().Trim()));
            if (DdlFiltrar.SelectedValue == "Todos")
            {
               
                GridView1.DataSource = LogicaPedido.ListarPorMedicamento(M);
                GridView1.DataBind();
            }
            else if (DdlFiltrar.SelectedValue == "Generados")
            {
                
                GridView1.DataSource = LogicaPedido.ListarPorMedicamentoGenerado(M);
                GridView1.DataBind();
            }
            else if (DdlFiltrar.SelectedValue == "Entregados")
            {
                GridView1.DataSource = LogicaPedido.ListarPorMedicamentoEntregado(M);
                GridView1.DataBind();
            }
        }
    }
}