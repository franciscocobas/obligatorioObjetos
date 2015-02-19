using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.ServiciosDominio;

namespace WebPruebas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sistema elSistema = Sistema.Instancia;
            Response.Write("Se agregaron " + elSistema.Habitaciones.Count + " Habitaciones");
            Response.Write("Se agregaron " + elSistema.Servicios.Count + " Servicios");
           
        }
    }
}