using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;

namespace WebPruebas
{
    public partial class LoginAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;

            // "UnobtrusiveValidationMode requires a ScriptResourceMapping for 'jquery'. Please add a ScriptResourceMapping named jquery"
            ScriptResourceDefinition jQuery = new ScriptResourceDefinition();
            jQuery.Path = "~/scripts/jquery-2.1.3.min.js";
            jQuery.DebugPath = "~/scripts/jquery-2.1.3.js";
            jQuery.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.min.js";
            jQuery.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery);
        }

        protected void LoginAdmin_Click(object sender, EventArgs e)
        {
            Sistema elSistema = Sistema.Instancia;
            string usuario = txt_usr.Text;
            string password = txt_pass.Text;

            Administrativo admin = elSistema.LoginAdmin(usuario, password);

            if (!Object.ReferenceEquals(null, admin))
            {
                Response.Redirect("controlPanelAdmin.aspx");
            }
            else
            {
                div_errorMessageDiv_login.InnerHtml = "<p style='color: #FF0000; font-size: 12px; margin:0px; font-family: &quot;Courier New&quot;, Courier, monospace'>Los datos ingresados son incorrectos</p>";
            }
        }

       
    }
}