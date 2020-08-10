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
    public partial class RealizarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Session["Usuario"] is Entidades_Compartidas.Usuario))
                    Response.Redirect("Default.aspx");

                

                if (!IsPostBack)
                {
                    GridView1.DataSource = LogicaMedicamento.Listar();
                    GridView1.DataBind();
                    BtnAceptar.Enabled = false;
                    BtnCancelar.Enabled = false;
                    BtnAceptar.Visible = false;
                    BtnCancelar.Visible = false;
                }
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void BtnPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente C = (Cliente)Session["Usuario"];
                Medicamento M = LogicaMedicamento.Buscar(GridView1.SelectedRow.Cells[1].Text.ToString().Trim(), Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text.ToString().Trim()));
                int cantidad = Convert.ToInt32(TxbCant.Text.Trim());
                Pedido P = new Pedido (0, M, C, cantidad, "Generado");

                Session["RealizarPedido"] = P;

                int precioTotal = (M._precio * cantidad);

                LblError.Text = " EL precio final es " + precioTotal + " presione aceptar para realizar el pedido";
                BtnAceptar.Enabled = true;
                BtnCancelar.Enabled = true;
                BtnAceptar.Visible = true;
                BtnCancelar.Visible = true;
                BtnPedido.Enabled = false;

            }
            catch (Exception ex)
            {
                LblError.Text = "Error" + ex.Message;
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pedido P = (Pedido)Session["RealizarPedido"];
                LogicaPedido.Eliminar(P);
                LblError.Text = "Se a realizado el pedido con exito";
                BtnAceptar.Enabled = false;
                BtnCancelar.Enabled = false;
                BtnAceptar.Visible = false;
                BtnCancelar.Visible = false;
                BtnPedido.Enabled = true;

            }
            catch (Exception ex)
            {
                LblError.Text = "Error" + ex.Message;
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            LblError.Text = "";
            Session["RealizarPedido"] = null;
            BtnAceptar.Enabled = false;
            BtnCancelar.Enabled = false;
            BtnAceptar.Visible = false;
            BtnCancelar.Visible = false;
            BtnPedido.Enabled = true;
        }
    }
}