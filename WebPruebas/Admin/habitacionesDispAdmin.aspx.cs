using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;

namespace WebPruebas.Admin
{
    public partial class habitacionesDispAdmin : System.Web.UI.Page
    {
        Sistema sistema = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<string> tipoHabitaciones = sistema.obtenerTipoHabitaciones();
                ddl_tipoHabitaciones.DataSource = tipoHabitaciones;
                ddl_tipoHabitaciones.DataBind();
                ddl_tipoHabitaciones.Items.Insert(0, "Seleccionar");
                hola.Visible = false;
            }
        }

        protected void ddl_tipoHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}