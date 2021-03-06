﻿using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPruebas
{
    public partial class ListarHabitaciones : System.Web.UI.Page
    {
        Sistema sistema = Sistema.Instancia;
        CotizacionDolar cotiz = CotizacionDolar.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<string> tipoHabitaciones = sistema.obtenerTipoHabitaciones();
                ddl_tipoHabitaciones.DataSource = tipoHabitaciones;
                ddl_tipoHabitaciones.DataBind();
                ddl_tipoHabitaciones.Items.Insert(0, new ListItem("--Ingrese un valor--"));
                grid_container.Visible = false;
                Session["dataColumns"] = null;
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
                    int cantidadHabitaciones;

                    List<Habitacion> habitaciones = sistema.ObtenerHabitacionesDisponiblesXTipo(fechaDesde, fechaHasta, ddl_tipoHabitaciones.SelectedItem.Value, out cantidadHabitaciones);
                    grid_container.Visible = true;

                    int cantidadPasajeros;
                    
                    List<ArrayList> diccHabitaciones = sistema.obtenerHabitacionesIguales(habitaciones, out cantidadPasajeros);
                    grid_view_habitaciones.AutoGenerateColumns = false;

                    string nuHabit = "Numero de Habitaciones disponibles";
                    string tieneJac = "Jacuzzi";
                    string esExt = "Exterior";
                    string cantCamSimples = "Cantidad de camas Simples";
                    string cantCamDobles = "Cantidad de camas Dobles";
                    string precio = "Precio ($U)";

                    DataTable table = new DataTable();
                    DataColumn columnNumHabit = new DataColumn(nuHabit, typeof(System.Int32));
                    table.Columns.Add(columnNumHabit);
                    DataColumn columnTieneJacuzzi = new DataColumn(tieneJac, typeof(System.Boolean));
                    table.Columns.Add(columnTieneJacuzzi);
                    DataColumn columnEsExterior = new DataColumn(esExt, typeof(System.Boolean));
                    table.Columns.Add(columnEsExterior);
                    DataColumn columnCantCamasSingles = new DataColumn(cantCamSimples, typeof(System.Int32));
                    table.Columns.Add(columnCantCamasSingles);
                    DataColumn columnCantCamasDobles = new DataColumn(cantCamDobles, typeof(System.Int32));
                    table.Columns.Add(columnCantCamasDobles);
                    DataColumn columnPrecio = new DataColumn(precio, typeof(System.Decimal));
                    table.Columns.Add(columnPrecio);


                    for (var i = 0; i < diccHabitaciones.Count ; i++)
                    {
                        DataRow row = table.NewRow();
                        row[nuHabit] = diccHabitaciones[i][0];
                        Habitacion habitacion = (Habitacion)diccHabitaciones[i][1];
                        row[tieneJac] = habitacion.TieneJacuzzi;
                        row[esExt] = habitacion.EsExterior;
                        row[cantCamSimples] = habitacion.CantCamasSingles;
                        row[cantCamDobles] = habitacion.CantCamasDobles;
                        row[precio] = habitacion.Precio.ConvertirAPesos(cotiz.PrecioVenta);
                        table.Rows.Add(row);
                    }

                    if (Session["dataColumns"] == null)
                    { 
                        foreach (DataColumn dc in table.Columns)
                        {
                            if (dc.DataType != typeof(System.Boolean))
                            { 
                                BoundField boundfield = new BoundField();
                                boundfield.DataField = dc.ColumnName;
                                boundfield.HeaderText = dc.ColumnName;
                                boundfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                grid_view_habitaciones.Columns.Add(boundfield);
                            } else
                            {
                                CheckBoxField checkbox = new CheckBoxField();
                                checkbox.DataField = dc.ColumnName;
                                checkbox.HeaderText = dc.ColumnName;
                                checkbox.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                grid_view_habitaciones.Columns.Add(checkbox);
                            }
                        }
                        Session["dataColumns"] = table.Columns;
                    }
                    
                    lbl_cant_total_pasajeros.Text = cantidadPasajeros.ToString();
                    lbl_cant_habitaciones.Text = cantidadHabitaciones.ToString();

                    grid_view_habitaciones.DataSource = table;
                    grid_view_habitaciones.DataBind();

                }
            }
        }

        protected void MostrarHabitaciones(object sender, EventArgs e)
        {
            if (txt_mayores.Text == "" || txt_menores.Text == ""){
                warn.Text = "*   Debe ingresar la cantidad de pasajeros mayores y menores";
                warn.ForeColor = Color.Red;
            }
            else
            {
                int cantPasajerosMayores;
                int cantPasajerosMenores;
                bool test = int.TryParse(txt_mayores.Text, out cantPasajerosMayores);
                bool test2 = int.TryParse(txt_menores.Text, out cantPasajerosMenores);

                if (test && test2)
                {
                    int cantidadPasajeros = int.Parse(lbl_cant_total_pasajeros.Text);
                    string fechaDesde = datepickerFrom.Value;
                    fechaDesde = fechaDesde.Replace("/", "");
                    string fechaHasta = datepickerTo.Value;
                    fechaHasta = fechaHasta.Replace("/", "");
                    string tipoHabitacion = ddl_tipoHabitaciones.SelectedItem.Value;
                    if (cantPasajerosMayores + cantPasajerosMenores <= cantidadPasajeros)
                    {
                        string doc = Request.QueryString["pDoc"];
                        string pais = Request.QueryString["pPais"];
                        Session["dataColumns"] = null;
                        Response.Redirect("SeleccionarHabitaciones.aspx?pDoc=" + doc + "&pPais=" + pais + "&pMay=" + cantPasajerosMayores.ToString() + "&pMen=" + cantPasajerosMenores
                            + "&fd=" + fechaDesde + "&fh=" + fechaHasta + "&type=" + tipoHabitacion);
                    }
                    else
                    {
                        warn.Text = "*    La cantidad total de pasajeros no puede exceder la capacidad total";
                        warn.ForeColor = Color.Red;
                    }
                }
                else
                {
                    warn.Text = "*    Debe ingresar números";
                    warn.ForeColor = Color.Red;
                }
            }
            
        }
    }
}

