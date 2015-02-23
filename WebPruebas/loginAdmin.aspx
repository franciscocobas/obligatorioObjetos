<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginAdmin.aspx.cs" Inherits="WebPruebas.LoginAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 id="h1_titleHome" style="font-family: 'Courier New', Courier, monospace; font-size: large; font-weight: normal; font-style: normal; color: #000080;">Log in</h1>
        <br />
        <br />
        <div id="div_1_login" >
            <asp:Label CssClass="cssLabels" ID="lbl_usr" runat="server" Text="Usuario">
                </asp:Label><asp:TextBox ID="txt_usr" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_usr" CssClass="validators" Display="Dynamic" ValidationGroup="loginValid"></asp:RequiredFieldValidator><br />
        </div>
        <br />
        <div id="div_2_login">            
            <asp:Label CssClass="cssLabels" ID="lbl_pass" runat="server" Text="Contraseña"></asp:Label><asp:TextBox ID="txt_pass" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_pass" Display="Dynamic" SetFocusOnError="True" ValidateRequestMode="Enabled" ValidationGroup="loginValid" ViewStateMode="Enabled" CssClass="validators"></asp:RequiredFieldValidator>
        </div>
        <br />
        
        <div id="div_errorMessageDiv_login" runat="server">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="loginValid" HeaderText="Debe ingresar ambos campos" CssClass="validators" />
        </div>
        <br />
        <div id="div_3_login"><asp:Button ID="Ingresar" runat="server" Text="Ingresar" OnClick="LoginAdmin_Click" ValidationGroup="loginValid" /></div>

        <br />
    </div>
    </form>
</body>
</html>
