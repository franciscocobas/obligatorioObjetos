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
        <div id="div_cantidades">
            <asp:Label Text="Cantidad pasajeros Mayores Seleccionados: " runat="server" /><asp:Label CssClass="cantPasajeros" ID="lbl_cant_mayores"  Text="" runat="server" />
            <br />
            <asp:Label Text="Cantidad pasajeros Menores Seleccionados: " runat="server" /><asp:Label CssClass="cantPasajeros" ID="lbl_cant_menores" Text="" runat="server" />
        </div>
        <br />
        <asp:Label Text="Cantidad de Matrimoniales: " runat="server" /><asp:TextBox ID="txt_cant_matrimoniales" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="ValCamas" ControlToValidate="txt_cant_matrimoniales"></asp:RequiredFieldValidator>
        <br />
        <asp:Label Text="Cantidad de Singles: " runat="server" /><asp:TextBox ID="txt_cant_singles" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ValCamas" ControlToValidate="txt_cant_singles"></asp:RequiredFieldValidator>
        <br />
        <br />
        <div id="div_errorCamas">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValCamas" CssClass="validators" HeaderText="Es necesario completar ambos campos" />
        </div>
        <asp:Button ID="BuscarHabitacion" Text="Buscar Habitacion" runat="server" OnClick="BuscarHabitacion_Click" ValidationGroup="ValCamas" />
        <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" PostBackUrl="~/Home.aspx" />
    </div>
    <div runat="server" id="listadoHabitaciones" visible="false">
        <div id="div_disponibles">   
            <asp:Label id="lbl_disp" Text="Habitaciones Disponibles:" runat="server" />
            <asp:GridView BorderColor="#CCCCCC" BorderStyle="Double" GridLines="Horizontal" CssClass="cssGrid" ID="gridHabitDisponibles" runat="server" AutoGenerateColumns="False"></asp:GridView>
            <div id="div_precios" runat="server">

            </div>
        </div>
        <div id="div_NOdisponibles">
            <asp:Label id="lbl_NOdisp" Text="No se puede reservar:" runat="server" />
            <asp:GridView BorderColor="#CCCCCC" BorderStyle="Double" GridLines="Horizontal" CssClass="cssGrid" ID="gridHabitNoDisponibles" runat="server"></asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
