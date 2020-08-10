<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MP.master" CodeBehind="ListarPedidos.aspx.cs" Inherits="ProyectoFinalBios.ListarPedidos" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div style="border: thin double #000000; text-align: center">
    
        <span class="style4"><strong>Listar Pedidos</strong></span><br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Width="1244px">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" 
            onclick="BtnEliminar_Click" />
        <br />
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
            font-size: xx-large;
        }
    </style>
</asp:Content>

