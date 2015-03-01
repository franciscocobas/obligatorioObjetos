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
using Dominio.ServiciosDominio;
using Dominio.EntidadesDominio;
using Dominio;

namespace WebPruebas
{
    public partial class controlPanelAdmin : System.Web.UI.Page
    {
        Sistema elsistema = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void dinero_Recaudado(object sender, EventArgs e)
        {
            CotizacionDolar cotiz = CotizacionDolar.Instancia;
            Precio dineroRec = elsistema.MostrarDineroRecaudado();
            div_mostrarDinero.InnerHtml = "<p>Se recaudaron $" + dineroRec.ConvertirAPesos(cotiz.PrecioCompra) + "</p>";
        }
    }
}