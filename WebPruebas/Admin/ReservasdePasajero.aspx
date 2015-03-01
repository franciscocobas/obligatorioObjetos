<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ReservasdePasajero.aspx.cs" Inherits="WebPruebas.Admin.ReservasdePasajero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_derivadas" runat="server">

    <div id="div_panel">

        <div id="div_p_reservasAdmin"><p id="p_reservasAdmin" class="cssLabels">Reservas de pasajeros</p></div>
        
        <div id="div_inputConsulta">

            <div id="div_P">
            <asp:Label ID="Label1" CssClass="cssLabels" runat="server" Text="Documento: " AssociatedControlID="docPasajero"></asp:Label><asp:DropDownList ID="docPasajero" AutoPostBack="true" OnSelectedIndexChanged="showCountryforDocs" CssClass="cssLabels" runat="server" ClientIDMode="Static"></asp:DropDownList>
            <div id="div_show" hidden="hidden">
                <asp:Label ID="Label_res2" CssClass="cssLabels" runat="server" Text="Pais: " AssociatedControlID="paisPasajero"></asp:Label><asp:DropDownList ID="paisPasajero" CssClass="cssLabels" runat="server"></asp:DropDownList>
                <asp:Button ID="btn_buscarRes" OnClick="buscar_Reservas_Pasajero" runat="server" Text="Buscar" />
            
            
            </div> 
            </div>
        </div>
            <div id="div_gridview2" runat="server" visible="false">
            
                <asp:GridView ID="GridView2" CssClass="cssGrid" runat="server" BorderColor="#CCCCCC" BorderStyle="Double" GridLines="Horizontal">
               
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
    <script src='../Scripts/jquery-2.1.3.min.js' type = 'text/javascript'></script>

    <script>
        jQuery(document).ready(function () {

            if ($("#docPasajero option:selected").text() != "Seleccionar") {
                $("#div_show").removeAttr("hidden");
            }
            else ($("#div_show").attr("hidden", "hidden"));
        });
    </script>

</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div id="div_btnVolver">
        <asp:Button ID="btn_volverPanel" PostBackUrl="~/Admin/controlPanelAdmin.aspx" runat="server" Text="Volver" Visible="true" />
    </div>

</asp:Content>


