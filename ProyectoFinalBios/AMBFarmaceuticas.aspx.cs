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
    public partial class AMBFarmaceuticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.LimpioFormulario();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string Ruc = TxbRuc.Text.Trim();
                Farmaceutica _objeto = LogicaFarmaceutica.Buscar(Ruc);

                if (_objeto == null)
                {
                    this.ActivoBotonesA();
                    Session["AMBFarmaceutica"] = null;
                }
                else
                {
                    this.ActivoBotonesBM();
                    Session["AMBFarmaceutica"] = _objeto;
                    TxbNombre.Text = _objeto._nombre.ToString();
                    TxbEmail.Text = _objeto._email.ToString();
                    TxbDir.Text = _objeto._dir.ToString();

                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            } 
        }

        private void ActivoBotonesA()
        {
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnAgregar.Enabled = true;
            BtnBuscar.Enabled = false;
            RfvEmail.Enabled = true;
            RfvNombre.Enabled = true;
            RfvDir.Enabled = true;
            RevRuc.Enabled = true;

            TxbRuc.Enabled = false;
        }
        private void ActivoBotonesBM()
        {
            BtnModificar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnAgregar.Enabled = false;
            BtnBuscar.Enabled = false;
            TxbRuc.Enabled = false;
            RfvEmail.Enabled = true;
            RfvNombre.Enabled = true;
            RfvDir.Enabled = true;
            RevRuc.Enabled = true;

        }

        private void LimpioFormulario()
        {

            BtnAgregar.Enabled = false;
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnBuscar.Enabled = true;
            TxbRuc.Enabled = true;
            RfvEmail.Enabled = false;
            RfvNombre.Enabled = false;
            RfvDir.Enabled = false;
            RevRuc.Enabled = false;


            TxbRuc.Text = "";
            TxbEmail.Text = "";
            TxbNombre.Text = "";
            TxbDir.Text = "";
            LblError.Text = "";
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                Farmaceutica F = new Farmaceutica(TxbRuc.Text.Trim(), TxbNombre.Text.Trim(), TxbEmail.Text.Trim(), TxbDir.Text.Trim());
                Logica.LogicaFarmaceutica.Alta(F);

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
                Farmaceutica F = (Farmaceutica)Session["AMBFarmaceutica"];
                F._ruc = TxbRuc.Text.Trim();
                F._nombre = TxbNombre.Text.Trim();
                F._email = TxbEmail.Text.Trim();
                F._dir = TxbDir.Text.Trim();

                Logica.LogicaFarmaceutica.Modificar(F);
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
            Farmaceutica F = (Farmaceutica)Session["AMBFarmaceutica"];

            if (LogicaMedicamento.ListarPorFarmaceutica(F) != null)
                LblError.Text = "se debe eliminar todos los medicamentos de la farmaceutica primero";
            else
            {
                
                    Logica.LogicaFarmaceutica.Baja(F);
                    this.LimpioFormulario();
                    LblError.Text = "Eliminacion con éxito";
                }
                
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

        protected void TxbNombre_TextChanged(object sender, EventArgs e)
        {

        }


    }
}