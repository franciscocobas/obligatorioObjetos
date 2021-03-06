﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarServicios.aspx.cs" Inherits="WebPruebas.SeleccionarServicios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seleccionar Servicios</title>
        <link href="styles.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="div_p_servicio"><p id="p_servicios" class="cssLabels">Seleccione los servicios para la reserva</p></div>
        <br />
        <div id="serviciosContainer">
            <asp:GridView CssClass="cssLabels" BorderColor="#CCCCCC" BorderStyle="Double" GridLines="Horizontal" ID="grid_view_servicios" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="seleccionado" runat="server" AutoPostBack="True" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"></asp:BoundField>
                    <asp:TemplateField HeaderText="Costo diario">
                        <ItemTemplate>
                            <asp:Label ID="costoPesos" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
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
        <div id="datos_servicios" class="cssLabels" runat="server">
            <div id="div_contr">
                <asp:Button ID="btn_cancelar" Text="Cancelar Reserva" runat="server" OnClick="CancelarReserva" />
                <asp:Button Text="Contratar Servicios" ID="btn_servicios" runat="server" OnClick="ContratarServicios" />
                <asp:Button ID="Volver_home" runat="server" Text="Inicio" PostBackUrl="~/Home.aspx" />
                <asp:Label ID="mensaje" Text="" runat="server" visible="false" ForeColor="#00CC00" />
                <p id="datos_de_reserva_final" runat="server">

                </p>
            </div>


        </div>
        <br />
    </div>
    </form>
</body>
</html>
