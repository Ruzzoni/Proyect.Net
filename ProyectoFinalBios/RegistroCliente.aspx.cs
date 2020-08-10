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
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.LimpioFormulario();

           
        
        }

        private void LimpioFormulario()
        {

            BtnAgregar.Enabled = false;
            BtnModificar.Enabled = false;
            BtnAgregarTel.Visible = false;
            BtnAgregarTel.Enabled = false;
            BtnEliminarTel.Visible = false;
            BtnEliminarTel.Enabled = false;
            LbTelefonos.Visible = false;
            LbTelefonos.Enabled = false;
            RfvApellido.Enabled = false;
            RfvNombre.Enabled = false;
            RfvPassword.Enabled = false;
            RfvDir.Enabled = false;
            RfvTel.Enabled = false;
            RevTel.Enabled = false;
            BtnBuscar.Enabled = true;

            TxbUsuario.Enabled = true;

            TxbUsuario.Text = "";
            TxbNombre.Text = "";
            TxbApellido.Text = "";
            TxbTelefono.Text = "";

            LblError.Text = "";
        }

        private void ActivoBotonesBM()
        {
            BtnModificar.Enabled = true;
            BtnAgregarTel.Visible = true;
            BtnAgregarTel.Enabled = true;
            BtnEliminarTel.Visible = true;
            BtnEliminarTel.Enabled = true;
            LbTelefonos.Visible = true;
            LbTelefonos.Enabled = true;
            

            BtnAgregar.Enabled = false;
            BtnBuscar.Enabled = false;

            TxbUsuario.Enabled = false;
        }

        private void ActivoBotonesA()
        {
            BtnModificar.Enabled = false;

            BtnAgregar.Enabled = true;
            BtnBuscar.Enabled = false;
            

            TxbUsuario.Enabled = false;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                String Login = TxbUsuario.Text;
                Cliente _objeto = (Cliente)Logica.LogicaUsuario.BuscarCliente(Login);

                if (_objeto == null)
                {
                    this.ActivoBotonesA();
                    Session["RegistroCliente"] = null;
                    RfvPassword.Enabled = true;
                    RfvDir.Enabled = true;
                    RfvApellido.Enabled = true;
                    RfvNombre.Enabled = true;
                    RfvTel.Enabled = true;
                    RevTel.Enabled = true;
                }
                else
                {
                    this.ActivoBotonesBM();
                    List<long> _telefonos = Logica.LogicaUsuario.BuscarTelefonos(Login);
                    _objeto.Telefonos = _telefonos;
                    Session["RegistroCliente"] = _objeto;
                    LbTelefonos.DataSource = _objeto.Telefonos;
                    LbTelefonos.DataBind();
                    TxbPassword.Text = _objeto._password.ToString();
                    TxbNombre.Text = _objeto._nombre.ToString();
                    TxbApellido.Text = _objeto._Apellido.ToString();
                    TxbDir.Text = _objeto._Dir.ToString();
                    RfvPassword.Enabled = true;
                    RfvDir.Enabled = true;
                    RfvApellido.Enabled = true;
                    RfvNombre.Enabled = true;
                    RfvTel.Enabled = true;
                    RevTel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

        protected void BtnAgregarTel_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clie = (Cliente)Session["RegistroCliente"];
                int numero = Convert.ToInt32(TxbTelefono.Text.Trim());

                Logica.LogicaUsuario.AgregarTelefono(clie._login, numero);

                List<long> _telefonos = Logica.LogicaUsuario.BuscarTelefonos(clie._login);

                LbTelefonos.DataSource = _telefonos;
                LbTelefonos.DataBind();
             

                LblError.Text = "se a agregado un nuevo telefono para el cliente";


            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

        protected void BtnEliminarTel_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clie = (Cliente)Session["RegistroCliente"];
                int numero = Convert.ToInt32(TxbTelefono.Text.Trim());

                Logica.LogicaUsuario.EliminarTelefono(clie._login, numero);

                LblError.Text = "Eliminacion con éxito";

                List<long> _telefonos = Logica.LogicaUsuario.BuscarTelefonos(clie._login);

                LbTelefonos.DataSource = _telefonos;
                LbTelefonos.DataBind();

              
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                List<long> telefono = new List<long>();
                telefono.Add(Convert.ToInt32(TxbTelefono.Text.Trim()));

                Cliente _unC = new Cliente(TxbUsuario.Text.Trim(), TxbPassword.Text.Trim(), TxbNombre.Text.Trim(), TxbApellido.Text.Trim(), TxbDir.Text.Trim(), telefono);

                Logica.LogicaUsuario.Agregar(_unC);

                this.LimpioFormulario();

                LblError.Text = "El cliente ah sido agregado con exito.";
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
                Cliente _unC = (Cliente)Session["RegistroCliente"];
                _unC._password = TxbPassword.Text.Trim();
                _unC._nombre = TxbNombre.Text.Trim();
                _unC._Apellido = TxbApellido.Text.Trim();
                _unC._Dir = TxbDir.Text.Trim();


                Logica.LogicaUsuario.Modificar(_unC);
                LblError.Text = "Modificacion con éxito";
                this.LimpioFormulario();
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

        protected void LbTelefonos_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxbTelefono.Text = LbTelefonos.SelectedValue.ToString();
        }
    }
}