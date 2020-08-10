<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeBehind="AMBEmpleados.aspx.cs" Inherits="ProyectoFinalBios.AMBEmpleados" %>


<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div style="border: thin double #000000">
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span class="style3"><strong>AMB De Empleado</strong></span>
        <br />
        <table class="style4">
            <tr>
                <td class="style8">
        <asp:Label ID="LblLogin" runat="server" Text="Nombre de Usuario:"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="TxbUsuario" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="BtnBuscar" runat="server"
            Text="Buscar" onclick="BtnBuscar_Click" />
                </td>
                <td class="style7">
&nbsp;
        <asp:RequiredFieldValidator ID="RfvUsuario" runat="server" 
            ControlToValidate="TxbUsuario" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style8">
        <asp:Label ID="LblPassword" runat="server" Text="Password:"></asp:Label>
                </td>
                <td class="style6">
        <asp:TextBox ID="TxbPassword" runat="server"></asp:TextBox>
                </td>
                <td class="style7">
        <asp:RequiredFieldValidator ID="RfvPassword" runat="server" 
            ControlToValidate="TxbPassword" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style8">
        <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td class="style6">
        <asp:TextBox ID="TxbNombre" runat="server" ontextchanged="TxbNombre_TextChanged"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:RequiredFieldValidator ID="RfvNombre" runat="server" 
            ControlToValidate="TxbNombre" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Label ID="LblApellido" runat="server" Text="Apellido:"></asp:Label>
                </td>
                <td class="style6">
        <asp:TextBox ID="TxbApellido" runat="server" ontextchanged="TxbApellido_TextChanged"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:RequiredFieldValidator ID="RfvApellido" runat="server" 
            ControlToValidate="TxbApellido" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style8">
        <asp:Label ID="LblHoraI" runat="server" Text="Horario: De:"></asp:Label>
                </td>
                <td class="style6">
        <asp:DropDownList ID="DdlHoraI" runat="server" onselectedindexchanged="DdlHoraI_SelectedIndexChanged" 
           >
        </asp:DropDownList>
&nbsp;
        <asp:Label ID="LblHoraF" runat="server" Text="Hasta:"></asp:Label>
&nbsp;<asp:DropDownList ID="DDLHoraF" runat="server">
        </asp:DropDownList>
                </td>
                <td class="style7">
&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Label ID="LblError" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Button ID="BtnAgregar" runat="server" 
            Text="Agregar" onclick="BtnAgregar_Click" Height="26px" />
        &nbsp;<asp:Button ID="BtnModificar" runat="server" 
            Text="Modificar" onclick="BtnModificar_Click" Height="26px" Width="77px" />
        &nbsp;<asp:Button ID="BtnEliminar" runat="server"  
            Text="Eliminar" onclick="BtnEliminar_Click" />
&nbsp;<asp:Button ID="BtnLimpiar" runat="server" 
            Text="Limpiar" onclick="BtnLimpiar_Click" />
                </td>
                <td class="style6">
&nbsp;
                </td>
                <td class="style7">
&nbsp;</td>
            </tr>
        </table>
        <br />
    
    </div>

</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style4
        {
            width: 100%;
            height: 217px;
        }
        .style6
        {
            width: 220px;
        }
        .style7
        {
            width: 207px;
        }
        .style8
        {
            width: 293px;
        }
    </style>
</asp:Content>


