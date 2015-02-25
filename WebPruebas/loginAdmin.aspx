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
        <div id="div_loginAdmin">
            <br />
            <asp:Login ID="LoginAdmin" runat="server" BackColor="#F7F6F3" onauthenticate="LoginAdmin_Authenticate" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" Width="279px" BorderPadding="4" FailureText="Try again." ForeColor="#333333" RememberMeText="Remember me." TitleText="Log In as Admin" UserNameLabelText="Username:" LoginButtonText="Log in" PasswordLabelText="Password">
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle BackColor="#FFFBFF"  BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#FFFFFF" Font-Size="0.9em" />
            </asp:Login>
        </div>
    </div>
    </form>
</body>
</html>
