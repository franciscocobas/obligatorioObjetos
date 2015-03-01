<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarHabitaciones.aspx.cs" Inherits="WebPruebas.ListarHabitaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listado de Habitaciones</title>
    <link href="../styles.css" rel="stylesheet" />
</head>
<body>
    <div runat="server" id="div_p_reservasAdmin2"><p id="p_reservasAdmin" class="cssLabels">Habitaciones disponibles</p></div> 
    <form id="form1" runat="server">
    <div>         
        <div id="div_LH">
            <div id="div_left">
                <asp:Label Text="Fecha desde: " CssClass="cssLabels" runat="server" /><input type="text" id="datepickerFrom" runat="server"/>
            </div>
            <div id="div_right">
                <asp:Label Text="Fecha hasta: " CssClass="cssLabels" runat="server" /><input type="text" id="datepickerTo" runat="server"/>
            </div>
            <br />
            <div id="div_tipoHab">
                <asp:Label Text="Tipo habitación: " CssClass="cssLabels" runat="server" /><asp:DropDownList ID="ddl_tipoHabitaciones" CssClass="cssLabels"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_tipoHabitaciones_SelectedIndexChanged"></asp:DropDownList>
            </div>  
        </div>
        <div id="hola" runat="server">
            <asp:GridView CssClass="cssLabels" ID="grid_view_habitaciones" runat="server" BorderColor="#CCCCCC" BorderStyle="Double" GridLines="Horizontal">
            </asp:GridView>

        </div>
    <//div>
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



