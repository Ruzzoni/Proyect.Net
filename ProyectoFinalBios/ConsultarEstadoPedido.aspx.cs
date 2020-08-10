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
    public partial class ConsultarEstadoPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LimpioFormulario();
                
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {  
            Pedido p ;  
            p = LogicaPedido.Buscar(Convert.ToInt32(TxbCodigo.Text.Trim()));
            LblError.Text = p._estado.ToString();
        }

        private void LimpioFormulario()
        {
            TxbCodigo.Text = "";
            BtnBuscar.Enabled = true;
            
            LblError.Text = "";
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpioFormulario();
        }
    }
}