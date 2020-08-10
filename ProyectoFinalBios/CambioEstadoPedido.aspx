<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MP.master" CodeBehind="CambioEstadoPedido.aspx.cs" Inherits="ProyectoFinalBios.CambioEstadoPedido" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="border: thin double #000000" class="style4">
    
        <div class="style4">
            &nbsp;<span class="style1"><strong><span class="style3" style="text-align: center">Cambiar estado del pedido</span><br />
            </strong></span><br />
        </div>
        <asp:GridView ID="GridView1" runat="server" Width="1081px" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
    
    </div>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .style4
    {
        text-align: center;
    }
</style>
</asp:Content>


