<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarHabitaciones.aspx.cs" Inherits="WebPruebas.SeleccionarHabitaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seleccionar habitaciones</title>
    <style>
        .cantPasajeros {
            font-weight: bold;
        }
    </style>
        <link href="styles.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="div_p_habs"><p id="p_servicios" class="cssLabels">Seleccione las habitaciones que desea reservar</p></div>
        <br />
        <asp:Label Text="Cantidad pasajeros Mayores Seleccionados: " runat="server" /><asp:Label CssClass="cantPasajeros" ID="lbl_cant_mayores"  Text="" runat="server" />
        <br />
        <asp:Label Text="Cantidad pasajeros Menores Seleccionados: " runat="server" /><asp:Label CssClass="cantPasajeros" ID="lbl_cant_menores" Text="" runat="server" />
        <br />
        <asp:Label Text="Cantidad de Matrimoniales: " runat="server" /><asp:TextBox ID="txt_cant_matrimoniales" runat="server" />
        <br />
        <asp:Label Text="Cantidad de Singles: " runat="server" /><asp:TextBox ID="txt_cant_singles" runat="server" />
        <br />
        <asp:Button ID="BuscarHabitacion" Text="Buscar Habitacion" runat="server" OnClick="BuscarHabitacion_Click" />
    </div>
    <div id="listadoHabitaciones">
        <asp:Label Text="Habitaciones Disponibles" runat="server" />
        <asp:GridView ID="gridHabitDisponibles" runat="server" AutoGenerateColumns="False"></asp:GridView>
        <asp:Label Text="Habitaciones No Disponibles" runat="server" />
        <asp:GridView ID="gridHabitNoDisponibles" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
