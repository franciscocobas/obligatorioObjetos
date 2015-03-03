using Dominio;
using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        List<Habitacion> habitacionesNoOcupadas = new List<Habitacion>();
        List<Habitacion> habitacionesSeleccionadas = new List<Habitacion>();

        ArrayList habitDisponiblesArray = new ArrayList();
        ArrayList habitNoDisponiblesArray = new ArrayList();

        DataTable tableDisponibles;
        DataTable tableNoDisponibles;

        string cantidadDobles = "Cantidad de Camas Dobles";
        string cantidadSingles = "Cantidad de Camas Singles";

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

            string type = Request.QueryString["type"];
            int cantidadHabitaciones;
            habitacionesNoOcupadas = sistema.ObtenerHabitacionesDisponiblesXTipo(fechaDesde, fechaHasta, type, out cantidadHabitaciones);

            gridHabitDisponibles.AutoGenerateColumns = false;
            gridHabitNoDisponibles.AutoGenerateColumns = false;

            if (!IsPostBack) {

                Session.Clear();

                habitacionesSeleccionadas = new List<Habitacion>();

                ArrayList habitDisponiblesArray = new ArrayList();
                ArrayList habitNoDisponiblesArray = new ArrayList();
                
                // Cargar habitaciones en disponibles
                lbl_cant_mayores.Text = Request.QueryString["pMay"];
                lbl_cant_menores.Text = Request.QueryString["pMen"];

                DataTable tableDisponibles = (DataTable)Session["tableDisponibles"];
                DataTable tableNoDisponibles = (DataTable)Session["tableNoDisponibles"];
                
                if (tableDisponibles == null && tableNoDisponibles == null)
                { 
                    tableDisponibles = new DataTable();
                    
                    DataColumn columnCantDobles = new DataColumn(cantidadDobles, typeof(System.Int32));
                    tableDisponibles.Columns.Add(columnCantDobles);
                    
                    DataColumn columnTCantSingles = new DataColumn(cantidadSingles, typeof(System.Int32));
                    tableDisponibles.Columns.Add(columnTCantSingles);

                    foreach (DataColumn dc in tableDisponibles.Columns)
                    {
                        BoundField boundfield = new BoundField();
                        boundfield.DataField = dc.ColumnName;
                        boundfield.HeaderText = dc.ColumnName;
                        boundfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        gridHabitDisponibles.Columns.Add(boundfield);
                    }

                    tableNoDisponibles = new DataTable();

                    DataColumn columnCantDoblesNoDisp = new DataColumn(cantidadDobles, typeof(System.Int32));
                    tableNoDisponibles.Columns.Add(columnCantDoblesNoDisp);

                    DataColumn columnCantSinglesNoDisp = new DataColumn(cantidadSingles, typeof(System.Int32));
                    tableNoDisponibles.Columns.Add(columnCantSinglesNoDisp);
                
                    foreach (DataColumn dc in tableNoDisponibles.Columns)
                    {
                        BoundField boundfield = new BoundField();
                        boundfield.DataField = dc.ColumnName;
                        boundfield.HeaderText = dc.ColumnName;
                        boundfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        gridHabitNoDisponibles.Columns.Add(boundfield);
                    }

                    Session["tableDisponibles"] = tableDisponibles;
                    Session["tableNoDisponibles"] = tableNoDisponibles;
                }   
            }
            else
            {
                habitDisponiblesArray = (ArrayList)Session["habitDisponiblesArray"];
                if (habitDisponiblesArray == null)
                    habitDisponiblesArray = new ArrayList();
                Session["habitDisponiblesArray"] = habitDisponiblesArray;

                habitNoDisponiblesArray = (ArrayList)Session["habitNoDisponiblesArray"];
                if (habitNoDisponiblesArray == null)
                    habitNoDisponiblesArray = new ArrayList();
                Session["habitNoDisponiblesArray"] = habitNoDisponiblesArray;

                habitacionesSeleccionadas = (List<Habitacion>)Session["HabitacionesSeleccionadas"];
                if (habitacionesSeleccionadas == null)
                    habitacionesSeleccionadas = new List<Habitacion>();
                Session["HabitacionesSeleccionadas"] = habitacionesSeleccionadas;
            }
        }

        protected void BuscarHabitacion_Click(object sender, EventArgs e)
        {
            Sistema elsistema = Sistema.Instancia;
            CotizacionDolar cotiz = CotizacionDolar.Instancia;

            int cantDobles;
            int cantSingles;
            habitacionesSeleccionadas = (List<Habitacion>)Session["HabitacionesSeleccionadas"];
            habitDisponiblesArray = (ArrayList)Session["habitDisponiblesArray"];
            habitNoDisponiblesArray = (ArrayList)Session["habitNoDisponiblesArray"];


            if (txt_cant_matrimoniales.Text != "" && txt_cant_singles.Text != "")
            {
                if (int.TryParse(txt_cant_matrimoniales.Text, out cantDobles) && int.TryParse(txt_cant_singles.Text, out cantSingles))
                {
                    listadoHabitaciones.Visible = true;

                    Habitacion habitacion = sistema.BuscarHabitacionXCama(habitacionesNoOcupadas, cantDobles, cantSingles, habitacionesSeleccionadas);

                    ArrayList cantidadCamasArray = new ArrayList();

                    cantidadCamasArray.Add(cantDobles);
                    cantidadCamasArray.Add(cantSingles);

                    tableDisponibles = (DataTable)Session["tableDisponibles"];
                    tableNoDisponibles = (DataTable)Session["tableNoDisponibles"];

                    if (habitacion != null)
                    {

                        habitDisponiblesArray.Add(cantidadCamasArray);
                        habitacionesSeleccionadas.Add(habitacion);
                        Session["HabitacionesSeleccionadas"] = habitacionesSeleccionadas;

                        Session["habitDisponiblesArray"] = habitDisponiblesArray;

                        DataRow row = tableDisponibles.NewRow();
                        row[cantidadDobles] = cantidadCamasArray[0];
                        row[cantidadSingles] = cantidadCamasArray[1];
                        tableDisponibles.Rows.Add(row);

                        gridHabitDisponibles.DataSource = tableDisponibles;
                        gridHabitDisponibles.DataBind();

                        decimal precioDolares;

                        precioDolares = elsistema.MostrarTarifaHabitaciones(habitacionesSeleccionadas).MontoDolares;

                        Precio resultPesos = new Precio(precioDolares);
                        decimal precioPesos;
                        precioPesos = resultPesos.ConvertirAPesos(cotiz.PrecioVenta); // compra o venta?

                        div_precios.InnerHtml = "<p>Costo de la reserva: $"+ precioPesos +"</p>";

                    }
                    else
                    {

                        habitNoDisponiblesArray.Add(cantidadCamasArray);

                        Session["habitNoDisponiblesArray"] = habitNoDisponiblesArray;

                        DataRow row = tableNoDisponibles.NewRow();
                        row[cantidadDobles] = cantidadCamasArray[0];
                        row[cantidadSingles] = cantidadCamasArray[1];
                        tableNoDisponibles.Rows.Add(row);

                        gridHabitNoDisponibles.DataSource = tableNoDisponibles;
                        gridHabitNoDisponibles.DataBind();

                    }
                }
            }           
        }
    }
}