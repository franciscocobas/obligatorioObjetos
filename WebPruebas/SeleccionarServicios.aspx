<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarServicios.aspx.cs" Inherits="WebPruebas.SeleccionarServicios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Seleccione los servicios para la reserva</h1>
        <div id="serviciosContainer">
            <asp:GridView ID="grid_view_servicios" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="seleccionado" runat="server" AutoPostBack="True" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"></asp:BoundField>
                    <asp:BoundField DataField="CostoDiario.MontoDolares" HeaderText="Costo diario en u$s"></asp:BoundField>
                    <asp:BoundField DataField="EdadMin" HeaderText="Edad m&#237;nima"></asp:BoundField>
                    <asp:BoundField DataField="EdadMax" HeaderText="Edad m&#225;xima"></asp:BoundField>
                    <asp:TemplateField HeaderText="Cantidad de días">
                        <ItemTemplate>
                            <asp:TextBox ID="cantDias" runat="server"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad de pasajeros">
                        <ItemTemplate>
                            <asp:TextBox ID="cantPasajeros" runat="server"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="datos_servicios" runat="server">
            <asp:Label Text="Cantidad de Días: " runat="server" /><asp:Label ID="lbl_cant_dias" runat="server" />
            <asp:Label Text="Cantidad de Pasajeros: " runat="server" /><asp:Label ID="lbl_cant_pasajeros" runat="server" />
            <asp:Button Text="Contratar Servicios" runat="server" OnClick="ContratarServicios" />
        </div>
        <asp:Label ID="mensaje" Text="" runat="server" visible="false" ForeColor="#00CC00" />
        <br />
        <asp:Button Text="Cancelar Reserva" runat="server" OnClick="CancelarReserva" />
    </div>
    </form>
</body>
</html>
