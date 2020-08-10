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
    public partial class AMBMedicamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    this.LimpioFormulario();
                    DdlRuc.DataSource = LogicaFarmaceutica.Listar();
                    DdlRuc.DataTextField = "_ruc";
                    DdlRuc.DataValueField = "_ruc";
                    DdlRuc.DataBind();
                    DdlRuc.SelectedIndex = 0;
                    Farmaceutica F = LogicaFarmaceutica.Buscar(DdlRuc.SelectedValue.ToString().Trim());
                    DdlCodigo.DataSource = LogicaMedicamento.ListarPorFarmaceutica(F);
                    DdlCodigo.DataTextField = "_codigo";
                    DdlCodigo.DataValueField = "_codigo";
                    DdlCodigo.DataBind();
                }
                catch (Exception ex)
                {
                    LblError.Text = ex.Message;
                }
                    
                    
            }
        }

        private void ActivoBotonesA()
        {
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnAgregar.Enabled = true;
            RfvRuc.Enabled = true;
        

            DdlRuc.Enabled = false;
        }
        private void ActivoBotonesBM()
        {
            BtnModificar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnAgregar.Enabled = false;
            DdlRuc.Enabled = false;
            DdlCodigo.Enabled = false;
            RfvRuc.Enabled = true;

        }

        private void LimpioFormulario()
        {

            BtnAgregar.Enabled = false;
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;
            DdlRuc.Enabled = true;
            DdlCodigo.Enabled = true;
            RfvNombre.Enabled = false;
            RfvPrecio.Enabled = false;
            RfvRuc.Enabled = false;

            TxbNombre.Text = "";
            TxbPrecio.Text = "";
            TxbDesc.Text = "";
            LblError.Text = "";
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                Medicamento M = new Medicamento(LogicaFarmaceutica.Buscar(DdlRuc.SelectedItem.Value.Trim()), 0, TxbNombre.Text.Trim(), Convert.ToInt32(TxbPrecio.Text.Trim()), TxbDesc.Text.Trim());

                Logica.LogicaMedicamento.Alta(M);

                this.LimpioFormulario();

                LblError.Text = "Empleado agregado con exito.";
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Medicamento M = LogicaMedicamento.Buscar(DdlRuc.SelectedItem.Value.Trim(), Convert.ToInt32(DdlCodigo.SelectedItem.Value.Trim()));
                M._nombre = TxbNombre.Text.Trim();
                M._precio = Convert.ToInt32(TxbPrecio.Text.Trim());
                M._desc = TxbDesc.Text.Trim();
                M._Farm = LogicaFarmaceutica.Buscar(DdlRuc.SelectedItem.Value.ToString().Trim());



                Logica.LogicaMedicamento.Modificar(M);
                LblError.Text = "Modificacion con éxito";

            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
            this.LimpioFormulario();
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Farmaceutica F = LogicaFarmaceutica.Buscar(DdlRuc.SelectedValue.ToString().Trim());
                int codigo = Convert.ToInt32(DdlCodigo.SelectedItem.Value.Trim());
                Medicamento M = LogicaMedicamento.Buscar(F._ruc, codigo);
                Logica.LogicaMedicamento.Eliminar(M);
                this.LimpioFormulario();
                LblError.Text = "Eliminacion con éxito";
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpioFormulario();
        }

        protected void TxbDesc_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DdlRuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            Farmaceutica F = LogicaFarmaceutica.Buscar(DdlRuc.SelectedValue.ToString().Trim());
            DdlCodigo.DataSource = LogicaMedicamento.ListarPorFarmaceutica(F);
            DdlCodigo.DataTextField = "_codigo";
            DdlCodigo.DataValueField = "_codigo";
            DdlCodigo.DataBind();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

        protected void BtnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActivoBotonesA();
                RfvNombre.Enabled = true;
                RfvPrecio.Enabled = true;
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

        protected void BtnBM_Click(object sender, EventArgs e)
        {
            
            try
            {
            Farmaceutica F = LogicaFarmaceutica.Buscar(DdlRuc.SelectedValue.ToString().Trim());
            int codigo = Convert.ToInt32(DdlCodigo.SelectedItem.Value.Trim());
            Medicamento M = LogicaMedicamento.Buscar(F._ruc,codigo );
            this.ActivoBotonesBM();
           TxbNombre.Text = M._nombre;
           TxbPrecio.Text = M._precio.ToString();
           TxbDesc.Text = M._desc;
           RfvNombre.Enabled = true;
           RfvPrecio.Enabled = true;
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }

        }
        
    }
}