<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoFinalBios.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 21%;
            height: 144px;
            border-style: solid;
            border-width: 2px;
        }
        .style2
        {
            width: 248px;
        }
        #form1
        {
            font-weight: 700;
        }
        .style3
        {
            font-size: xx-large;
            text-decoration: underline;
            text-align: center;
        }
        .style4
        {
            font-weight: normal;
            text-align: center;
        }
        .style5
        {
            text-align: center;
        }
    </style>
</head>
<body bgcolor="#99ffcc" style="height: 311px">
    <form id="form1" runat="server">
    <div class="style5">
        <span class="style3">Farmaceutica Bios</span><br />
        <span class="style4">Proyecto Final</span><br />
    <br />
    </div>
    <table align="center" class="style1" style="background-color: #FFFFFF">
        <tr>
            <td bgcolor="White" class="style2" style="border: thin outset #000000">
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LblUser" runat="server" Text="Usuario:"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TxbLogin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td bgcolor="White" class="style2" style="border: thin outset #000000">
&nbsp;&nbsp;
                <asp:Label ID="LblPassword" runat="server" Text="Password:"></asp:Label>
&nbsp;
                <asp:TextBox ID="TxbPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td bgcolor="White" class="style2" style="border: thin outset #000000">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnLogin" runat="server" style="text-align: center" 
                    Text="Login" onclick="BtnLogin_Click" />
            </td>
        </tr>
        <tr>
            <td bgcolor="White" class="style2" style="border: thin outset #000000">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    </form>
</body>
</html>
