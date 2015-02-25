<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarHabitaciones.aspx.cs" Inherits="WebPruebas.ListarHabitaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listado de Habitaciones</title>
    <link href="../styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="Fecha desde: " runat="server" /><input type="text" id="datepickerFrom" runat="server"/>
        <asp:Label Text="Fecha hasta: " runat="server" /><input type="text" id="datepickerTo" runat="server"/>
        <br />
        <asp:Label Text="Tipo habitación: " runat="server" /><asp:DropDownList ID="ddl_tipoHabitaciones" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_tipoHabitaciones_SelectedIndexChanged"></asp:DropDownList>
        <div id="hola" runat="server">
            <asp:GridView ID="grid_view_habitaciones" runat="server"></asp:GridView>
        </div>
    </div>
    </form>
    <script src='../Scripts/jquery-2.1.3.min.js' type = 'text/javascript'></script>
    <script src="//code.jquery.com/ui/1.11.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.3/themes/smoothness/jquery-ui.css"/>
    <script>
        jQuery(document).ready(function ($) {
            
            $.datepicker.setDefaults({
                dateFormat: 'dd/mm/yy'
            });
            $('#datepickerFrom, #datepickerTo').datepicker({
                minDate: 0
            });
        });
    </script>
</body>
</html>



