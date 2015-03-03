<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarHabitaciones.aspx.cs" Inherits="WebPruebas.ListarHabitaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listado de Habitaciones</title>
    <link href="../styles.css" rel="stylesheet" />
    <style>
        #grid_container {
            width: 85%;
            height: auto;
            margin: 0px auto;
        }
        #grid_container div {
            width: 100%;
            overflow: auto;
        }
        #grid_container table {
            width: 100%;
        }
        .line_form {
            margin: 5px 0px 5px 0px;
        }
        .line_form span:first-child {
            width: 40%;
        }
        #lbl_cant_total_pasajeros, #warn {
            font-weight: bold;
            font-size: 15px;
            font-family:'Times New Roman', Times, serif
        }
    </style>
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
        <div id="grid_container" runat="server">
            <asp:GridView CssClass="cssLabels" ID="grid_view_habitaciones" runat="server" BorderColor="#CCCCCC" BorderStyle="Double" GridLines="Horizontal">
            </asp:GridView>

            <div class="line_form">
                <asp:Label runat="server" CssClass="cssLabels" Text="Numero total de Pasajeros que se pueden alojar: "></asp:Label><asp:Label ID="lbl_cant_total_pasajeros" CssClass="cssLabels" runat="server" Text=""></asp:Label>
                <asp:Label  id="warn" runat="server"></asp:Label>
            </div>
            <div class="line_form">
                <asp:Label CssClass="cssLabels" Text="Ingrese la cantidad de Mayores se alojarán: " runat="server" /><asp:TextBox ID="txt_mayores" runat="server" />
            </div>
            <div class="line_form">
                <asp:Label CssClass="cssLabels" Text="Ingrese la cantidad de Menores se alojarán" runat="server" /><asp:TextBox ID="txt_menores" runat="server" />
            </div>
            <asp:Button Text="Ver Habitaciones Disponibles" runat="server" OnClick="MostrarHabitaciones" />

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

            var dateFrom = $('#datepickerFrom'),
                dateTo = $('#datepickerTo');
            
            dateTo.on('change', function (e) {
                dateFrom = dateFrom.val();
                dateTo = dateTo.val();
                var dateFromDate = $.datepicker.parseDate('dd/mm/yy', dateFrom),
                    dateToDate = $.datepicker.parseDate('dd/mm/yy', dateTo);
                if (dateToDate < dateFromDate) {
                    console.log('hola');
                }
            });
            

        });
    </script>
</body>
</html>



