<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarHabitaciones.aspx.cs" Inherits="WebPruebas.SeleccionarHabitaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl_cant_pasajeros" Text="Cantidad Pasajeros" runat="server" />
        <asp:GridView ID="grid_habitaciones_disponibles" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Seleccionar">
                    <ItemTemplate>
                        <asp:CheckBox ID="seleccionado" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id"></asp:BoundField>
                <asp:BoundField HeaderText="Numero" DataField="Numero"></asp:BoundField>
                <asp:BoundField DataField="TieneJacuzzi" HeaderText="Tiene Jacuzzi?"></asp:BoundField>
                <asp:BoundField DataField="EsExterior" HeaderText="Es Exterior?"></asp:BoundField>
                <asp:BoundField DataField="CantCamasSingles" HeaderText="Cantidad de camas Simples"></asp:BoundField>
                <asp:BoundField DataField="CantCamasDobles" HeaderText="Cantidad de camas Dobles"></asp:BoundField>
                <asp:BoundField DataField="Precio.MontoDolares" HeaderText="Precio"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Button Text="Calcular Total" runat="server" OnClick="calcularPrecioTotal" />
        <asp:Label Text="Monto total en u$s: " runat="server" /><asp:Label ID="lbl_monto_total" runat="server" />
        <asp:Button Text="Elegir Servicios" runat="server" OnClick="CrearReserva" />
    </div>
    </form>
</body>
</html>
