using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using System;
using System.Web.UI.WebControls;


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