<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="WebPruebas.ModificarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 runat="server" id="editTitle">Modificar datos pasajero</h1>
        <h1 runat="server" id ="inputTitle">Ingresar pasajero</h1>
        <asp:Label ID="Nombre" CssClass="labelsDatos" runat="server" Text="Label">Nombre</asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Dirección" runat="server" Text="Label">Dirección</asp:Label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
