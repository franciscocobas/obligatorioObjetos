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
    public partial class SeleccionarHabitaciones : System.Web.UI.Page
    {
        Sistema sistema = Sistema.Instancia;
        DateTime fechaDesde;
        DateTime fechaHasta;
        int cantidadPasajerosMayores;
        int cantidadPasajerosMenores;

        protected void Page_Load(object sender, EventArgs e)
        {
            cantidadPasajerosMayores = int.Parse(Request.QueryString["pMay"]);
            cantidadPasajerosMenores = int.Parse(Request.QueryString["pMen"]);

            char[] fechaDesdeChar = Request.QueryString["fd"].ToCharArray();
            string diaDesde = fechaDesdeChar[0].ToString() + fechaDesdeChar[1].ToString();
            string mesDesde = fechaDesdeChar[2].ToString() + fechaDesdeChar[3].ToString();
            string anioDesde = fechaDesdeChar[4].ToString() + fechaDesdeChar[5].ToString() + fechaDesdeChar[6].ToString() + fechaDesdeChar[7].ToString();
            fechaDesde = new DateTime(int.Parse(anioDesde), int.Parse(mesDesde), int.Parse(diaDesde));

            char[] fechaHastaChar = Request.QueryString["fh"].ToCharArray();
            string diaHasta = fechaHastaChar[0].ToString() + fechaHastaChar[1].ToString();
            string mesHasta = fechaHastaChar[2].ToString() + fechaHastaChar[3].ToString();
            string anioHasta = fechaHastaChar[4].ToString() + fechaHastaChar[5].ToString() + fechaHastaChar[6].ToString() + fechaHastaChar[7].ToString();
            fechaHasta = new DateTime(int.Parse(anioHasta), int.Parse(mesHasta), int.Parse(diaHasta));

            if (!IsPostBack) { 

                string type = Request.QueryString["type"];

                // Cargar habitaciones en disponibles
                List<Habitacion> habitacionesDisponibles = sistema.ObtenerHabitacionesDisponiblesXTipo(fechaDesde, fechaHasta, type);
                lbl_cant_mayores.Text = Request.QueryString["pMay"];
                lbl_cant_menores.Text = Request.QueryString["pMen"];

                grid_habitaciones_disponibles.AutoGenerateColumns = false;
                grid_habitaciones_disponibles.DataSource = habitacionesDisponibles;
                grid_habitaciones_disponibles.DataBind();

                // Cargar habitaciones en no disponibles
                List<Habitacion> habitacionesNoDisponibles = sistema.ObtenerHabitacionesNoDisponiblesXTipo(fechaDesde, fechaHasta, type);
                if (habitacionesNoDisponibles.Count > 0)
                {
                    grid_habitaciones_no_disp.AutoGenerateColumns = false;
                    grid_habitaciones_no_disp.DataSource = habitacionesNoDisponibles;
                    grid_habitaciones_no_disp.DataBind();
                }
                
            }
        }

        protected void calcularPrecioTotal(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            decimal precioTotal = 0M;
            foreach(GridViewRow row in grid_habitaciones_disponibles.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox check = (row.Cells[0].FindControl("seleccionado") as CheckBox);
                    if (check.Checked)
                    {
                        list.Add(row.Cells[1].Text);
                        int id = int.Parse(row.Cells[1].Text);
                        precioTotal += sistema.buscarHabitacionXId(id).Precio.MontoDolares;
                    }
                }
            }
            lbl_monto_total.Text = precioTotal.ToString();
        }

        protected void CrearReserva(object sender, EventArgs e)
        {
            List<int> habitacionesSeleccionadas = new List<int>();
            decimal precioPesos = 0;
            foreach (GridViewRow row in grid_habitaciones_disponibles.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox check = (row.Cells[0].FindControl("seleccionado") as CheckBox);
                    if (check.Checked)
                    {
                        int id = int.Parse(row.Cells[1].Text);
                        habitacionesSeleccionadas.Add(id);
                        Habitacion habitacionEncontrada = sistema.buscarHabitacionXId(id);
                        precioPesos += habitacionEncontrada.Precio.ConvertirAPesos(CotizacionDolar.Instancia.PrecioCompra);
                    }
                }
            }
            int doc = int.Parse(Request.QueryString["pDoc"]);
            string pais = Request.QueryString["pPais"];
            sistema.CrearReserva(doc, pais, precioPesos, fechaDesde, fechaHasta, cantidadPasajerosMayores, cantidadPasajerosMenores, habitacionesSeleccionadas);
        }
    }
}