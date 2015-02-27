<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="habitacionesDispAdmin.aspx.cs" Inherits="WebPruebas.Admin.habitacionesDispAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        jQuery(document).ready(function ($) {
            console.log('hola');
            $.datepicker.setDefaults({
                dateFormat: 'dd/mm/yy'
            });
            $('#Content_derivadas_datepickerFromHab, #Content_derivadas_datepickerToHab').datepicker({
                minDate: 0
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_derivadas" runat="server">

    <div id="div_panel">

        <div id="div_p_reservasAdmin"><p id="p_reservasAdmin" class="cssLabels">Habitaciones disponibles</p></div> 

        <div id="div_H">
        <div id="div_left"><asp:Label Text="Fecha desde: " CssClass="cssLabels" runat="server" /><input type="text" id="datepickerFromHab" runat="server"/>
        </div>
            <div id="div_right"><asp:Label Text="Fecha hasta: " CssClass="cssLabels" runat="server" /><input type="text" id="datepickerToHab" runat="server"/></div>
        

        <br />
        <div id="div_tipoHab">
            <asp:Label CssClass="cssLabels" Text="Tipo habitación: " runat="server" /><asp:DropDownList ID="ddl_tipoHabitaciones" CssClass="cssLabels" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_tipoHabitaciones_SelectedIndexChanged"></asp:DropDownList>
        </div>
        
        </div>    
        <br />
        <div id="hola" runat="server">
            <asp:GridView ID="grid_view_habitaciones" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div id="div_btnVolver">
        <asp:Button ID="btn_volverPanel" PostBackUrl="~/Admin/controlPanelAdmin.aspx" runat="server" Text="Volver" Visible="true" />
    </div>

</asp:Content>