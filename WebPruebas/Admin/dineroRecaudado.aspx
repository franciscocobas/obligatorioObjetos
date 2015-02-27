<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="dineroRecaudado.aspx.cs" Inherits="WebPruebas.Admin.dineroRecaudado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_derivadas" runat="server">

    <div id="div_panel">

        <div id="div_p_reservasAdmin"><p id="p_reservasAdmin" class="cssLabels">Dinero recaudado</p></div> 

    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div id="div_btnVolver">
        <asp:Button ID="btn_volverPanel" runat="server" PostBackUrl="~/Admin/controlPanelAdmin.aspx" Text="Volver" Visible="true" />
    </div>

</asp:Content>