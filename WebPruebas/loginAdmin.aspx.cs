using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using Dominio.Utilidades;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebPruebas
{
    public partial class LoginAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;
            ScriptResourceDefinition jQuery = new ScriptResourceDefinition();
            jQuery.Path = "~/scripts/jquery-2.1.3.min.js";
            jQuery.DebugPath = "~/scripts/jquery-2.1.3.js";
            jQuery.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.min.js";
            jQuery.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery); 
        }

        protected void LoginAdmin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Sistema elSistema = Sistema.Instancia;
            Administrativo a = elSistema.ValidarLogin(this.LoginAdmin.UserName,this.LoginAdmin.Password);

            if (a != null)
            {
                Session["Admin"] = a; 
                e.Authenticated = true;
                this.LoginAdmin.DestinationPageUrl = "Admin/controlPanelAdmin.aspx";
            }
               
            else
            {
                Session["usuario"] = null;
                e.Authenticated = false;
                this.LoginAdmin.DestinationPageUrl = "Admin/controlPanelAdmin.aspx";

            }
        }

    }
}