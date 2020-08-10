<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="ProyectoFinalBios.RegistroCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
            font-size: xx-large;
        }
        .style2
        {
            width: 100%;
        }
    </style>
</head>
<body bgcolor="#99ffcc">
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span class="style1"><strong>Registro de cliente</strong></span><br />
        <table class="style2">
            <tr>
                <td>
        <asp:Label ID="LblLogin" runat="server" Text="Nombre de Usuario:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxbUsuario" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="BtnBuscar" runat="server" onclick="BtnBuscar_Click" 
            Text="Buscar" />
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RfvUsuario" runat="server" 
            ControlToValidate="TxbUsuario" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="LblPassword" runat="server" Text="Password:"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TxbPassword" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RfvPassword" runat="server" 
            ControlToValidate="TxbPassword" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TxbNombre" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvNombre" runat="server" 
            ControlToValidate="TxbNombre" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblApellido" runat="server" Text="Apellido:"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TxbApellido" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvApellido" runat="server" 
            ControlToValidate="TxbApellido" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="LblDir" runat="server" Text="Direccion:"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TxbDir" runat="server"></asp:TextBox>
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RfvDir" runat="server" 
            ControlToValidate="TxbDir" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblTel" runat="server" Text="Telefono"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TxbTelefono" runat="server"></asp:TextBox>
        &nbsp;<asp:ListBox ID="LbTelefonos" runat="server" AutoPostBack="True" 
             Width="168px" onselectedindexchanged="LbTelefonos_SelectedIndexChanged">
        </asp:ListBox>
        &nbsp;<asp:Button ID="BtnAgregarTel" runat="server" onclick="BtnAgregarTel_Click" 
            Text="Guardar" Width="70px" />
        &nbsp;<asp:Button ID="BtnEliminarTel" runat="server" onclick="BtnEliminarTel_Click" 
            Text="Eliminar" Width="70px" />
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RfvTel" runat="server" 
            ControlToValidate="TxbTelefono" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RevTel" runat="server" 
                        ControlToValidate="TxbTelefono" 
                        ErrorMessage="debe ingresar un numero de telefono" ValidationExpression="^\d+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="LblError" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnAgregar" runat="server" onclick="BtnAgregar_Click" 
            Text="Agregar" />
        &nbsp;<asp:Button ID="BtnModificar" runat="server" onclick="BtnModificar_Click" 
            Text="Modificar" style="margin-top: 0px" />
        &nbsp;<asp:Button ID="BtnLimpiar" runat="server" onclick="BtnLimpiar_Click" 
            Text="Limpiar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Principal.aspx">Volver</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        &nbsp;&nbsp;
        &nbsp;&nbsp;
        <br />
        <br />
&nbsp;
        &nbsp;
        <br />
        <br />
        &nbsp;&nbsp;
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;
        &nbsp;<br />
        <br />
&nbsp;
        &nbsp;
        <br />
        <br />
        &nbsp;&nbsp;
        &nbsp;&nbsp;
        &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;<br />
        <br />
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        &nbsp;<br />
    
    </div>
    </form>
</body>
</html>
