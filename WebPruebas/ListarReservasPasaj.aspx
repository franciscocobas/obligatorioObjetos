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
        <div id="div_volver"><asp:Button ID="btn_volver" runat="server" OnClick="Volver" Text="Volver" /></div>
        <div id="div_gridview">
            <asp:GridView ID="GridView1" CssClass="cssGrid" runat="server" BorderColor="#CCCCCC" BorderStyle="Double" GridLines="Horizontal">
               <Columns>
                    <asp:BoundField DataField="CantMenores" HeaderText="Cantidad Menores"></asp:BoundField>
                    <asp:BoundField DataField="CantMayores" HeaderText="Cantidad Mayores"></asp:BoundField>
                    <asp:BoundField DataField="PrecioPesos" HeaderText="Precio"></asp:BoundField>
                    <asp:BoundField DataField="FechaDesde" HeaderText="Fecha desde" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                    <asp:BoundField DataField="FechaHasta" HeaderText="Fecha hasta" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                </Columns>
            </asp:GridView>

        </div>
        
    </div>
    </form>
</body>
</html>
