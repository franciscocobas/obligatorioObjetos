using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPruebas
{
    public partial class ListarHabitaciones : System.Web.UI.Page
    {
        Sistema sistema = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<string> tipoHabitaciones = sistema.obtenerTipoHabitaciones();
                ddl_tipoHabitaciones.DataSource = tipoHabitaciones;
                ddl_tipoHabitaciones.DataBind();
                hola.Visible = false;
            }
        }

        protected void ddl_tipoHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_tipoHabitaciones.SelectedItem != null && datepickerFrom.Value != "" && datepickerTo.Value != "")
            {
                string[] fechaDesdeArray = datepickerFrom.Value.Split('/');
                string[] fechaHastaArray = datepickerTo.Value.Split('/');
                string diaDesdeTexto = fechaDesdeArray[0];
                string diaHastaTexto = fechaHastaArray[0];
                int diaDesde;
                int diaHasta;
                string mesDesdeTexto = fechaDesdeArray[1];
                string mesHastaTexto = fechaHastaArray[1];
                int mesDesde;
                int mesHasta;
                string anioDesdeTexto = fechaDesdeArray[2];
                string anioHastaTexto = fechaHastaArray[2];
                int anioDesde;
                int anioHasta;
                if (int.TryParse(diaDesdeTexto, out diaDesde) && int.TryParse(mesDesdeTexto, out mesDesde)
                        && int.TryParse(anioDesdeTexto, out anioDesde) && int.TryParse(anioHastaTexto, out anioHasta)
                        && int.TryParse(mesHastaTexto, out mesHasta) && int.TryParse(diaHastaTexto, out diaHasta))
                {
                    DateTime fechaDesde = new DateTime(anioDesde, mesDesde, diaDesde);
                    DateTime fechaHasta = new DateTime(anioHasta, mesHasta, diaHasta);
                    List<Habitacion> habitaciones = sistema.ObtenerHabitacionesDisponiblesXTipo(fechaDesde, fechaHasta, ddl_tipoHabitaciones.SelectedItem.Value);

                }


            }
        }
    }
}

