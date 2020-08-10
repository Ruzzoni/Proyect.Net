<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarEstadoPedido.aspx.cs" Inherits="ProyectoFinalBios.ConsultarEstadoPedido" %>

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
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span class="style1"><strong>Consultar Estado del Pedido</strong></span><br />
        <asp:Label ID="LblCodigo" runat="server" Text="Codigo Pedido:"></asp:Label>
&nbsp;
        <asp:TextBox ID="TxbCodigo" runat="server" style="margin-bottom: 0px"></asp:TextBox>
&nbsp;
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" 
            onclick="BtnBuscar_Click" />
        <br />
        <br />
        <table class="style2">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
        <asp:Label ID="LblError" runat="server" ForeColor="#0066FF"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button ID="BtnLimpiar" runat="server" Text="limpiar"  style="width: 56px" 
            onclick="BtnLimpiar_Click" />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Principal.aspx">Volver</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
