<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeBehind="RealizarPedido.aspx.cs" Inherits="ProyectoFinalBios.RealizarPedido" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="border: thin double #000000; text-align: center;">
    
        <strong><span class="style4"><span class="style5">Realizar Pedido</span></span></strong><br />
        <asp:GridView ID="GridView1" runat="server" Width="1067px">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="LblCantidad" runat="server" Text="Cantidad:"></asp:Label>
&nbsp;
        <asp:TextBox ID="TxbCant" runat="server"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RfvCantidad" runat="server" 
            ControlToValidate="TxbCant" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LblError" runat="server"></asp:Label>
        <br />
        <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" 
            onclick="BtnAceptar_Click"  />
        &nbsp;<asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" 
            onclick="BtnCancelar_Click"  />
        <br />
        <asp:Button ID="BtnPedido" runat="server" Text="Realizar Pedido" 
            onclick="BtnPedido_Click" />
        <br />
    
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style4
        {
            width: 100%;
            height: 90px;
            text-decoration: underline;
        }
        .style5
        {
            font-size: xx-large;
        }
    </style>
</asp:Content>
