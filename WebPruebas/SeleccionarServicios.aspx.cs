using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

            CotizacionDolar cotiz = CotizacionDolar.Instancia;

            if (int.TryParse(Request.QueryString["id"], out id) && int.TryParse(Request.QueryString["pDoc"], out idPasajero))
            {
                reserva = sistema.buscarReservaXId(id);
                pasajero = sistema.BuscarPasajeroPorId(idPasajero);
            }

            List<Servicio> servicios = sistema.Servicios;

            if (!IsPostBack)
            {
                grid_view_servicios.AutoGenerateColumns = false;
                grid_view_servicios.DataSource = servicios;
                grid_view_servicios.DataBind();
            }

            ArrayList a = new ArrayList();

            foreach (Servicio s in servicios)
            {
                a.Add(s.CostoDiario.ConvertirAPesos(cotiz.PrecioVenta).ToString());
            }

            for (var i = 0; i < servicios.Count; i++)
            {
                GridViewRow r = grid_view_servicios.Rows[i];
                if (r.RowType == DataControlRowType.DataRow)
                {
                    r.Cells[3].Text = (string)a[i];
                }
            }
        }

        protected void ContratarServicios(object sender, EventArgs e)
        {
            arrayServiciosSeleccionados = new ArrayList();
            CotizacionDolar cotiz = CotizacionDolar.Instancia;
            bool hayCheckeado = false;

            foreach (GridViewRow row in grid_view_servicios.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox check = (row.Cells[0].FindControl("seleccionado") as CheckBox);
                    if (check.Checked)
                    {
                        hayCheckeado = true;
                        ArrayList servicio = new ArrayList();
                        TextBox cantDias = (row.Cells[6].FindControl("cantDias") as TextBox);
                        TextBox cantPas = (row.Cells[7].FindControl("cantPasajeros") as TextBox);

                        if (cantDias.Text != "" && cantPas.Text != "")
                        {
                            servicio.Add(row.Cells[1].Text);
                            servicio.Add(cantDias.Text);
                            servicio.Add(cantPas.Text);
                            arrayServiciosSeleccionados.Add(servicio);
                            mensaje.Visible = true;

                        }
                        else
                        {
                            mensaje.Visible = true;
                            mensaje.Text = "Ingresar cantidad de días y pasajeros de las selecciones";
                            mensaje.ForeColor = Color.Red;
                        }

                    }
                }
            }

            if (arrayServiciosSeleccionados != null && arrayServiciosSeleccionados.Count > 0)
            {
                for (var i = 0; i < arrayServiciosSeleccionados.Count; i++)
                {
                    ArrayList arrayServicio;
                    arrayServicio = (ArrayList)arrayServiciosSeleccionados[i];
                    int cantDias;
                    int cantPasajeros;
                    int idServicio;

                    bool test = int.TryParse(arrayServicio[1].ToString(), out cantDias);
                    bool test2 = int.TryParse(arrayServicio[2].ToString(), out cantPasajeros);
                    bool test3 = int.TryParse(arrayServicio[0].ToString(), out idServicio);

                    if (test && test2 && test3)
                    {
                        Servicio servicio = sistema.BuscarServicioXId(idServicio);
                        if (servicio != null)
                        {
                            reserva.AgregarContrato(servicio, cantDias, cantPasajeros);

                            mensaje.Visible = true;
                            mensaje.Text = "Servicios agregados Correctamente";
                            mensaje.ForeColor = Color.Green;
                            decimal total = reserva.PrecioPesos;
                            btn_servicios.Enabled = false;
                            datos_de_reserva_final.InnerText = "Precio total: $" + total;
                        }
                    }
                }
            }
            else if (arrayServiciosSeleccionados.Count == 0 && hayCheckeado == false)
            {
                mensaje.Visible = true;
                mensaje.Text = "No se agregaron servicios";
                mensaje.ForeColor = Color.Green;
                decimal total = reserva.PrecioPesos;
                btn_servicios.Enabled = false;
                datos_de_reserva_final.InnerText = "Precio total: $" + total;
            }
        }

        protected void CancelarReserva(object sender, EventArgs e)
        {
            Sistema elsistema = Sistema.Instancia;
            int doc = int.Parse(Request.QueryString["pDoc"]);
            string pais = Request.QueryString["pais"];
            int idRes = int.Parse(Request.QueryString["id"]);

            elsistema.CancelarReserva(doc, pais, idRes);

            Response.Redirect("Home.aspx");
        }
    }
}