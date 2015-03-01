<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarReservasPasaj.aspx.cs" Inherits="WebPruebas.ListarReservasPasaj" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listado de Reservas</title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="div_p_listaRes"><p runat="server" class="cssLabels" id="titulo"></p></div>
        <div id="div_gridview">
            <asp:GridView ID="GridView1" CssClass="cssLabels" runat="server" BorderColor="#CCCCCC" BorderStyle="Double" GridLines="Horizontal"></asp:GridView>

        </div>
    </div>
    </form>
</body>
</html>
