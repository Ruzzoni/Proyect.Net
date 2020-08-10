<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MP.master" CodeBehind="ListadoMedicamentosPedidos.aspx.cs" Inherits="ProyectoFinalBios.ListadoMedicamentosPedidos" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="border: thin double #000000; text-align: center">
    
        <br />
        <span class="style4"><strong>Listar Medicamentos y Pedidos<br />
        </strong></span><br />
        <table class="style5">
            <tr>
                <td>
        <asp:Label ID="LblRuc" runat="server" Text="Ruc:"></asp:Label>
&nbsp;<asp:DropDownList ID="DdlRuc" runat="server" 
            onselectedindexchanged="DdlRuc_SelectedIndexChanged">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
        <asp:GridView ID="GridView1" runat="server" Width="1223px" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
        <asp:DropDownList ID="DdlFiltrar" runat="server" 
            ontextchanged="DdlFiltrar_TextChanged">
            <asp:ListItem>Todos</asp:ListItem>
            <asp:ListItem>Generados</asp:ListItem>
            <asp:ListItem>Entregados</asp:ListItem>
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
        <asp:GridView ID="GridView2" runat="server" Width="1215px">
        </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
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
        .style5
        {
            width: 100%;
        }
    </style>
</asp:Content>
