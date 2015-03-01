<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarVerUsuario.aspx.cs" Inherits="WebPruebas.ModificarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="titulo"></title>
    <link href="styles.css" rel="stylesheet" />
    <script src='Scripts/jquery-2.1.3.min.js' type = 'text/javascript'></script>
<%--    <script type="text/javascript">
        jQuery(document).ready(function inicio() {
            divAlertaInicio = "<p style='color: #FF0000; font-size: 12px; margin:0px; font-family: &quot;Courier New&quot;, Courier, monospace'>";
            divAlertaFin = "</p>";

            validarJQ();

        });

        function validarJQ(){
  
            nom_val = $("#txt_nombre").val();
            ciudad_val = $("#txt_ciudad").val();
            dpto_val = $("#txt_dptoProv").val();

            char = true;
            for (i = 0; i < nom_val.length; i++) {
                if (!isNaN(nom_val[i])) {
                    if (nom_val[i] != " ") {
                        char = false;
                    }
                }
                else { char = true; }

            };
            if (!char) {
                $("#div_jqueryValid").html(divAlertaInicio + "El nombre no puede contener números" + divAlertaFin);
            }
            else { $("#div_jqueryValid").html(""); }

            char = true;
            for (i = 0; i < ciudad_val.length; i++) {
                if (!isNaN(ciudad_val[i])) {
                    if (ciudad_val[i] != " ") {
                        char = false;
                    }
                }
                else { char = true; }

            };

            if (!char) {
                $("#div_jqueryValid").html(divAlertaInicio + "La ciudad no puede contener números" + divAlertaFin);
            }
            else { $("#div_jqueryValid").html(""); }

            char = true;
            for (i = 0; i < dpto_val.length; i++) {
                if (!isNaN(dpto_val[i])) {
                    if (dpto_val[i] != " ") {
                        char = false;
                    }
                }
                else { char = true; }

            };

            if (!char) {
                $("#div_jqueryValid").html(divAlertaInicio + "El departamento/provincia no puede contener números" + divAlertaFin);
            }
            else { $("#div_jqueryValid").html(""); }
        }


    </script>--%>
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
            <asp:Label ID="lbl_nombre" CssClass="cssLabels" runat="server" Text="Nombre"></asp:Label><asp:TextBox ID="txt_nombre2" runat="server"></asp:TextBox>            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validators" Display="Dynamic" ValidationGroup="ValidatorIngreso" ControlToValidate="txt_nombre2">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorA" CssClass="validators" runat="server" ControlToValidate="txt_nombre2" ValidationExpression="^(?=.*?[A-Za-z])[^0-9]+$" ValidationGroup="expressionsIngr"></asp:RegularExpressionValidator>

        </div>
        <br />
        <div id="div_5">
            <asp:Label ID="lbl_dirección1" CssClass="cssLabels" runat="server" Text="Dirección 1"></asp:Label><asp:TextBox ID="txt_dir1" runat="server"></asp:TextBox>            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="validators" Display="Dynamic" ValidationGroup="ValidatorIngreso" ControlToValidate="txt_dir1">*</asp:RequiredFieldValidator>       
        </div>
        <br />
        <div id="div_6">
            <asp:Label ID="lbl_dirección2" CssClass="cssLabels" runat="server" Text="Dirección 2"></asp:Label><asp:TextBox ID="txt_dir2" runat="server"></asp:TextBox>
        </div>
        <br />
        <div id="div_7">
            <asp:Label ID="lbl_ciudad" CssClass="cssLabels" runat="server" Text="Ciudad"></asp:Label><asp:TextBox ID="txt_ciudad2" runat="server"></asp:TextBox>            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="validators" Display="Dynamic" ValidationGroup="ValidatorIngreso" ControlToValidate="txt_ciudad2">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorB" CssClass="validators" runat="server" ControlToValidate="txt_ciudad2" ValidationExpression="^(?=.*?[A-Za-z])[^0-9]+$" ValidationGroup="expressionsIngr"></asp:RegularExpressionValidator>        
        </div>
        <br />

        <div id="div_8">
            <asp:Label ID="lbl_dptoProv" CssClass="cssLabels" runat="server" Text="Dpto/Provincia"></asp:Label><asp:TextBox ID="txt_dptoProv2" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="validators" Display="Dynamic" ValidationGroup="ValidatorIngreso" ControlToValidate="txt_dptoProv2">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorC" CssClass="validators" runat="server" ControlToValidate="txt_dptoProv2" ValidationExpression="^(?=.*?[A-Za-z])[^0-9]+$" ValidationGroup="expressionsIngr"></asp:RegularExpressionValidator>
        </div>
        <br /> 
        <div id="div_9">
            <asp:Label ID="lbl_CP" CssClass="cssLabels" runat="server" Text="Código postal"></asp:Label><asp:TextBox ID="txt_CP" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_CP" Display="Dynamic" ValidationGroup="ValidatorIngreso" CssClass="validators">*</asp:RequiredFieldValidator>
        </div>
        <br />
        <div id="div_10">
            <asp:Label ID="lbl_paisResid" CssClass="cssLabels" runat="server" Text="País Residencia"></asp:Label><asp:DropDownList ID="drp_paisResid" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drp_paisResid" CssClass="validators" Display="Dynamic" InitialValue="Seleccionar" ValidationGroup="ValidatorIngreso">*</asp:RequiredFieldValidator>
        </div>
        <br />
        <br />
        <div id="div_errorMessageDiv2" runat="server">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validators" ValidationGroup="ValidatorIngreso" DisplayMode="List" EnableTheming="True" HeaderText="Los campos con * son obligatorios"/>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="validators" ValidationGroup="expressionsIngr" DisplayMode="List" EnableTheming="True" HeaderText="Nombre, ciudad y Departamento/provincia no pueden contener números" />

        </div>
        <div id="div_11">
            <asp:Button ID="btn_cancelar" runat="server" OnClick="Cancelar_Click" Text="Cancelar" />            
            <asp:Button ID="btn_modifDato" runat="server" OnClick="Modificar_Click" Text="Modificar datos" />
            <asp:Button ID="btn_hacerReserva" runat="server" OnClick="Reserva_Click" ValidationGroup="ValidatorIngreso" Text="Aceptar y continuar con la reserva" />
        </div>
    </div>
    </form>
</body>
</html>
