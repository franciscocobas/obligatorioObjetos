<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="controlPanelAdmin.aspx.cs" Inherits="WebPruebas.controlPanelAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content_derivadas" runat="server">
    <div id="div_panel">
        <div id="div_habitaciones">
            <asp:LinkButton ID="lnk_habs" PostBackUrl="~/Admin/habitacionesDispAdmin.aspx" runat="server" CssClass="cssLabels csslinks" ForeColor="#333399" Font-Size="Large">Listar habitaciones disponibles entre fechas</asp:LinkButton>
        </div>       
         <div id="div_reservas">
            <asp:LinkButton ID="lnk_reservas" PostBackUrl="~/Admin/ReservasdePasajero.aspx" runat="server" CssClass="cssLabels csslinks" ForeColor="#333399" Font-Size="Large">Listar reservas próximas de pasajeros</asp:LinkButton>
        </div>
        <div id="div_dinero">
            <asp:LinkButton ID="lnk_dinero" OnClick="dinero_Recaudado" runat="server" CssClass="cssLabels csslinks" ForeColor="#333399" Font-Size="Large">Obtener dinero recaudado en pesos</asp:LinkButton>
        </div>
        <div id="div_mostrarDinero" runat="server">

        </div>
    </div>
        
</asp:Content>
