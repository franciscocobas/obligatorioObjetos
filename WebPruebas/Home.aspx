<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebPruebas.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body class=" ">
    <form id="form1" runat="server">
    <div>

        <h1 style="font-family: 'Courier New', Courier, monospace; font-size: large; font-weight: normal; font-style: normal; color: #000080;">Haz tu reserva aquí</h1>
        <asp:TextBox ID="txt_documento" runat="server" onblur="if(this.value=='')this.value=this.defaultValue;" value="Documento" onfocus="if(this.value==this.defaultValue)this.value=''"></asp:TextBox>
        <br />
        <asp:DropDownList ID="drp_Pais" runat="server"></asp:DropDownList> 

        <br />

        <asp:Button ID="Submit" runat="server" Text="Hacer reserva" OnClick="Submit_Click" />
        <br />
    </div>
    </form>
</body>
</html>
