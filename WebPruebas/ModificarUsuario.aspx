<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="WebPruebas.ModificarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="titulo"></title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 style="font-family: 'Courier New', Courier, monospace; font-size: large; font-weight: normal; font-style: normal; color: #000080;" runat="server" id="h1_editTitle">Datos del pasajero</h1>
        <h1 style="font-family: 'Courier New', Courier, monospace; font-size: large; font-weight: normal; font-style: normal; color: #000080;" runat="server" id ="h1_inputTitle">Ingresar pasajero</h1>
        <br />
        <div id="div_1" >
            <asp:Label CssClass="cssLabels" ID="lbl_doc" runat="server" Text="Documento"></asp:Label><asp:TextBox ID="txt_documento2" runat="server"></asp:TextBox>
        </div>
        <br />
        <div id="div_2">            
            <asp:Label CssClass="cssLabels" ID="lbl_pais" runat="server" Text="País emisor"></asp:Label><asp:DropDownList ID="drp_Pais2" runat="server"></asp:DropDownList>
        </div>  
        <br />     
        <div id="div_4">
            <asp:Label ID="lbl_nombre" CssClass="cssLabels" runat="server" Text="Nombre"></asp:Label><asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
        </div>
        <br />
        <div id="div_5">
            <asp:Label ID="lbl_dirección1" CssClass="cssLabels" runat="server" Text="Dirección 1"></asp:Label><asp:TextBox ID="txt_dir1" runat="server"></asp:TextBox>
        </div>
        <br />
        <div id="div_6">
            <asp:Label ID="lbl_dirección2" CssClass="cssLabels" runat="server" Text="Dirección 2"></asp:Label><asp:TextBox ID="txt_dir2" runat="server"></asp:TextBox>
        </div>
        <br />
        <div id="div_7">
            <asp:Label ID="lbl_ciudad" CssClass="cssLabels" runat="server" Text="Ciudad"></asp:Label><asp:TextBox ID="txt_ciudad" runat="server"></asp:TextBox>
        </div>
        <br />

        <div id="div_8">
            <asp:Label ID="lbl_dptoProv" CssClass="cssLabels" runat="server" Text="Dpto/Provincia"></asp:Label><asp:TextBox ID="txt_dptoProv" runat="server"></asp:TextBox>
        </div>
        <br /> 
        <div id="div_9">
            <asp:Label ID="lbl_CP" CssClass="cssLabels" runat="server" Text="Código postal"></asp:Label><asp:TextBox ID="txt_CP" runat="server"></asp:TextBox>
        </div>
        <br />
        <div id="div_10">
            <asp:Label ID="lbl_paisResid" CssClass="cssLabels" runat="server" Text="País Residencia"></asp:Label><asp:DropDownList ID="drp_paisResid" runat="server"></asp:DropDownList>
        </div>
        <br />
        <br />
        <div id="div_11">
            <asp:Button ID="btn_modifDato" runat="server" Text="Modificar datos" />
            <asp:Button ID="btn_hacerReserva" runat="server" Text="Hacer reserva" />
        </div>
    </div>
    </form>
</body>
</html>
