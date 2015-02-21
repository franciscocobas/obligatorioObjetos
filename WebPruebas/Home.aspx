<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebPruebas.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body class=" ">
    <form id="form1" runat="server">
    <div>
        <h1 id="h1_titleHome" style="font-family: 'Courier New', Courier, monospace; font-size: large; font-weight: normal; font-style: normal; color: #000080;">Haz tu reserva aquí</h1>
        <br />
        <br />
        <div id="div_1" >
            <asp:Label CssClass="cssLabels" ID="lbl_doc" runat="server" Text="Documento"></asp:Label><asp:TextBox ID="txt_documento" runat="server"></asp:TextBox>
        </div>
        <br />
        <div id="div_2">            
            <asp:Label CssClass="cssLabels" ID="lbl_pais" runat="server" Text="País emisor"></asp:Label><asp:DropDownList ID="drp_Pais" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div id="div_errorMessageDiv" runat="server"></div>
        <div id="div_3"><asp:Button ID="Submit" runat="server" Text="Hacer reserva" OnClick="Submit_Click" /></div>

        <br />
    </div>
    </form>
</body>
</html>
