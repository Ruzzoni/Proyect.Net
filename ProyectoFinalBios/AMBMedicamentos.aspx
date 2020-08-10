<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeBehind="AMBMedicamentos.aspx.cs" Inherits="ProyectoFinalBios.AMBMedicamentos" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="border: thin double #000000">
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span class="style1"><strong>&nbsp;<span class="style3">AMB de Medicamentos</span></strong></span><br />
        <table class="style4">
            <tr>
                <td>
                    <asp:Label ID="LblRUC" runat="server" Text="RUC:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlRuc" runat="server" 
                        onselectedindexchanged="DdlRuc_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
                &nbsp;<asp:Label ID="LblCodigo" runat="server" Text="Codigo:"></asp:Label>
                &nbsp;<asp:DropDownList ID="DdlCodigo" runat="server" 
                        onselectedindexchanged="DdlRuc_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
                &nbsp;<asp:Button ID="BtnAlta" runat="server" 
            Text="Alta" onclick="BtnAlta_Click" Width="48px" />
        &nbsp;<asp:Button ID="BtnBM" runat="server" 
            Text="Baja/modificacion" onclick="BtnBM_Click" style="height: 26px" />
                </td>
                <td>
        <asp:RequiredFieldValidator ID="RfvRuc" runat="server" 
            ControlToValidate="DdlRuc" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TxbNombre" runat="server"></asp:TextBox>
                &nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvNombre" runat="server" 
            ControlToValidate="TxbNombre" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPrecio" runat="server" Text="Precio:"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TxbPrecio" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvPrecio" runat="server" 
            ControlToValidate="TxbPrecio" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblDesc" runat="server" Text="Descripcion:"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="TxbDesc" runat="server" Height="48px" Width="329px" 
                        ontextchanged="TxbDesc_TextChanged"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
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
&nbsp;<asp:Button ID="BtnAgregar" runat="server" 
            Text="Agregar" onclick="BtnAgregar_Click" style="height: 26px" />
        &nbsp;<asp:Button ID="BtnModificar" runat="server"  
            Text="Modificar" onclick="BtnModificar_Click" />
        &nbsp;<asp:Button ID="BtnEliminar" runat="server" 
            Text="Eliminar" onclick="BtnEliminar_Click" />
        &nbsp;<asp:Button ID="BtnLimpiar" runat="server" 
            Text="Limpiar" onclick="BtnLimpiar_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;
        &nbsp;<br />
        <br />
        &nbsp;&nbsp; &nbsp;<br />
        <br />
        <br />
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style4
        {
            width: 100%;
        }
    </style>
</asp:Content>
