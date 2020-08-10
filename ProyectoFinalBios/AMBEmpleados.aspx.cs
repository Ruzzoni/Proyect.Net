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
    public partial class AMBEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            { 
                this.LimpioFormulario();
                DdlHoraI.DataSource = GetTimeIntervals();
                DdlHoraI.DataBind();
                DDLHoraF.DataSource = GetTimeIntervals();
                DDLHoraF.DataBind();
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                String _Login = TxbUsuario.Text.Trim();
                Empleado _objeto = (Empleado)Logica.LogicaUsuario.BuscarEmpleado(_Login);

                if (_objeto == null)
                {
                    this.ActivoBotonesA();
                    Session["AMBEmpleados"] = null;
                }
                else
                {
                    this.ActivoBotonesBM();
                    Session["AMBEmpleados"] = _objeto;
                    TxbPassword.Text = _objeto._password.ToString();
                    TxbNombre.Text = _objeto._nombre.ToString();
                    TxbApellido.Text = _objeto._Apellido.ToString();
                    

                    

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
            RfvPassword.Enabled = true;
            RfvNombre.Enabled = true;
            RfvApellido.Enabled = true;
            TxbUsuario.Enabled = false;
        }
        private void ActivoBotonesBM()
        {
            BtnModificar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnAgregar.Enabled = false;
            BtnBuscar.Enabled = false;
            TxbUsuario.Enabled = false;
            RfvPassword.Enabled = true;
            RfvNombre.Enabled = true;
            RfvApellido.Enabled = true;

        }

        private void LimpioFormulario()
        {

            BtnAgregar.Enabled = false;
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnBuscar.Enabled = true;
            TxbUsuario.Enabled = true;
            RfvPassword.Enabled = false;
            RfvNombre.Enabled = false;
            RfvApellido.Enabled = false;


            TxbUsuario.Text = "";
            TxbPassword.Text = "";
            TxbNombre.Text = "";
            TxbApellido.Text = "";
            LblError.Text = "";
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                Empleado unE = new Empleado(TxbUsuario.Text.Trim(), TxbPassword.Text.Trim(), TxbNombre.Text.Trim(), TxbApellido.Text.Trim(), DdlHoraI.SelectedValue.ToString(), DDLHoraF.SelectedValue.ToString());

                Logica.LogicaUsuario.Agregar(unE);

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
                Empleado unE = (Empleado)Session["AMBEmpleados"];
                unE._password = TxbPassword.Text.Trim();
                unE._nombre = TxbNombre.Text.Trim();
                unE._Apellido = TxbApellido.Text.Trim();
                unE._horai = DdlHoraI.SelectedValue.ToString();
                unE._horaf = DDLHoraF.SelectedValue.ToString();
                


                Logica.LogicaUsuario.Modificar(unE);
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
            Empleado unE = (Empleado)Session["AMBEmpleados"];
            Usuario Ua = (Usuario)Session["Usuario"];
            if (unE._login != Ua._login)
            {
                try
                {
                    Logica.LogicaUsuario.Eliminar(unE);
                    this.LimpioFormulario();
                    LblError.Text = "Eliminacion con éxito";
                }
                catch (Exception ex)
                {
                    LblError.Text = ex.Message;
                }
            }
            else
                LblError.Text = "Error no se puede eliminar el usuario actualmente logueado";
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpioFormulario();
        }

        public List<string> GetTimeIntervals()
        {
            List<string> timeIntervals = new List<string>();
            TimeSpan startTime = new TimeSpan(0, 0, 0);
            DateTime startDate = new DateTime(DateTime.MinValue.Ticks); // Date to be used to get shortTime format.
            for (int i = 0; i < 48; i++)
            {
                int minutesToBeAdded = 30 * i;      // Increasing minutes by 30 minutes interval
                TimeSpan timeToBeAdded = new TimeSpan(0, minutesToBeAdded, 0);
                TimeSpan t = startTime.Add(timeToBeAdded);
                DateTime result = startDate + t;
                timeIntervals.Add(result.ToShortTimeString().Trim());      // Use Date.ToShortTimeString() method to get the desired format                
            }
            return timeIntervals;
        }

        protected void DdlHoraI_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void DdlRuc_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void TxbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxbApellido_TextChanged(object sender, EventArgs e)
        {

        }

    }
}