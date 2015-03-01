using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPruebas
{
    public partial class SeleccionarServicios : System.Web.UI.Page
    {
        Sistema sistema = Sistema.Instancia;
        Reserva reserva = null;
        Pasajero pasajero = null;
        ArrayList arrayServiciosSeleccionados = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            int idPasajero;

            if (int.TryParse(Request.QueryString["id"], out id) && int.TryParse(Request.QueryString["idP"], out idPasajero))
            {
                reserva = sistema.buscarReservaXId(id);
                pasajero = sistema.BuscarPasajeroPorId(idPasajero);
            }

            if (!IsPostBack)
            {
                List<Servicio> servicios = sistema.Servicios;
                grid_view_servicios.AutoGenerateColumns = false;
                grid_view_servicios.DataSource = servicios;
                grid_view_servicios.DataBind();

                arrayServiciosSeleccionados = new ArrayList();

                foreach (GridViewRow row in grid_view_servicios.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox check = (row.Cells[0].FindControl("seleccionado") as CheckBox);
                        if (check.Checked)
                        {
                            ArrayList servicio = new ArrayList();
                            servicio.Add(row.Cells[1].Text);
                            servicio.Add((row.Cells[6].FindControl("cantDias") as TextBox));
                            servicio.Add((row.Cells[7].FindControl("cantPasajeros") as TextBox));
                            arrayServiciosSeleccionados.Add(servicio);
                        }
                    }
                }
            }
        }

        protected void ContratarServicios(object sender, EventArgs e)
        {
            if (pasajero != null && reserva != null)
            {
                if (arrayServiciosSeleccionados != null && arrayServiciosSeleccionados.Count > 0)
                {
                    for (var i = 0; i < arrayServiciosSeleccionados.Count; i++)
                    {
                        ArrayList arrayServicio;
                        try {
                            arrayServicio = (ArrayList)arrayServiciosSeleccionados[i];
                            TextBox cantDiasTextBox = (TextBox)arrayServicio[1];
                            TextBox cantPasajerosTextBox = (TextBox)arrayServicio[2];

                            int idServicio;
                            int cantidadDias;
                            int cantidadPasajeros;

                            if (int.TryParse(arrayServicio[0].ToString(), out idServicio) 
                                && int.TryParse(cantDiasTextBox.Text, out cantidadDias)
                                && int.TryParse(cantPasajerosTextBox.Text, out cantidadPasajeros))
                            {
                                Servicio servicio = sistema.BuscarServicioXId(idServicio);
                                if (servicio != null)
                                {
                                    reserva.AgregarContrato(servicio, cantidadDias, cantidadPasajeros);
                                }
                            }
                        } 
                        catch (Exception exception)
                        {
                            Console.Write(exception.Message);
                        }
                    }
                }
                datos_servicios.Visible = false;
                mensaje.Visible = true;
                mensaje.Text = "Servicios agregados Correctamente";
            }
        }

        protected void CancelarReserva(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}