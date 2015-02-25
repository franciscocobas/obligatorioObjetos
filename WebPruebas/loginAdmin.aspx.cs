using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace WebPruebas
{
    public partial class LoginAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["usuarioActivo"] != null)
            //{
            //    this.LoginPag.Visible = false;
            //    this.LnkCerrarSesion.Visible = true;
            //    this.Registro.Visible = false;
            //}
        }

        protected void LoginAdmin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Sistema elSistema = Sistema.Instancia;
            Administrativo a = elSistema.ValidarLogin(this.LoginAdmin.UserName,this.LoginAdmin.Password);

            if (a != null)
            {
                Session["usuarioActivo"] = a;
                e.Authenticated = true;
                this.LoginAdmin.DestinationPageUrl = "controlPanelAdmin.aspx";
            }
               
            else
            {
                Session["usuarioActivo"] = null;
                e.Authenticated = false;
            }
        }

    }
}