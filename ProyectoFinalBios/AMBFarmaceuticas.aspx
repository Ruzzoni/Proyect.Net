<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeBehind="AMBFarmaceuticas.aspx.cs" Inherits="ProyectoFinalBios.AMBFarmaceuticas" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="style4" style="border: thin double #000000">
    
        <span class="style1"><strong>
        <span class="style3" 
            style="text-align: center;">AMB de Farmaceuticas</span></strong></span><br />
        <table class="style5">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="LblRUC" runat="server" Text="RUC:"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="TxbRuc" runat="server" MaxLength="12"></asp:TextBox>
        &nbsp;<asp:Button ID="BtnBuscar" runat="server"  
            Text="Buscar" onclick="BtnBuscar_Click" />
                </td>
                <td style="text-align: left">
        <asp:RegularExpressionValidator ID="RevRuc" runat="server" 
            ControlToValidate="TxbRuc" 
            ErrorMessage="ingrese un numero de 12 digitos para la cedula" 
            ValidationExpression="\d{12}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td style="text-align: left">
        <asp:TextBox ID="TxbNombre" runat="server" ontextchanged="TxbNombre_TextChanged"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator ID="RfvNombre" runat="server" 
            ControlToValidate="TxbNombre" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
                </td>
                <td class="style6">
        <asp:TextBox ID="TxbEmail" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                </td>
                <td class="style6">
                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server" 
            ControlToValidate="TxbEmail" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="LblDir" runat="server" Text="Direccion:"></asp:Label>
                </td>
                <td class="style6">
        <asp:TextBox ID="TxbDir" runat="server"></asp:TextBox>
                </td>
                <td class="style6">
                    <asp:RequiredFieldValidator ID="RfvDir" runat="server" 
            ControlToValidate="TxbDir" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    <asp:Label ID="LblError" runat="server"></asp:Label>
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style6">
                    <asp:Button ID="BtnAgregar" runat="server" 
            Text="Agregar" onclick="BtnAgregar_Click" />
        &nbsp;<asp:Button ID="BtnModificar" runat="server" 
            Text="Modificar" onclick="BtnModificar_Click" />
        &nbsp;<asp:Button ID="BtnEliminar" runat="server"  
            Text="Eliminar" onclick="BtnEliminar_Click" />
        &nbsp;<asp:Button ID="BtnLimpiar" runat="server" 
            Text="Limpiar" onclick="BtnLimpiar_Click" />
                </td>
                <td class="style6">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;
        &nbsp;<br />
        <br />
        &nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
    
    </div>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .style4
    {
        text-align: center;
    }
        .style5
        {
            width: 100%;
        }
        .style6
        {
            text-align: left;
        }
    </style>
</asp:Content>


