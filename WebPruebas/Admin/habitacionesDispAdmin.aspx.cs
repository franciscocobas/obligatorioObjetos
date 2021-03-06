﻿using System;
using System.Data;
using System.Collections;
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
                hola2.Visible = false;
                Session["dataColumns"] = null;
            }
        }

        protected void ddl_tipoHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddl_tipoHabitaciones.SelectedItem != null && datepickerFromHab.Value != "" && datepickerToHab.Value != "")
            {
                string[] fechaDesdeArray = datepickerFromHab.Value.Split('/');
                string[] fechaHastaArray = datepickerToHab.Value.Split('/');
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
                    hola2.Visible = true;
                    int cantidadPasajeros;
                    List<ArrayList> diccHabitaciones = sistema.obtenerHabitacionesIguales(habitaciones, out cantidadPasajeros);
                    grid_view_habitaciones.AutoGenerateColumns = false;

                    string nuHabit = "Numero de Habitaciones disponibles";
                    string tieneJac = "Jacuzzi";
                    string esExt = "Exterior";
                    string cantCamSimples = "Cantidad de camas Simples";
                    string cantCamDobles = "Cantidad de camas Dobles";
                    string precio = "Precio (U$S)";

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

                    for (var i = 0; i < diccHabitaciones.Count; i++)
                    {
                        DataRow row = table.NewRow();
                        row[nuHabit] = diccHabitaciones[i][0];
                        Habitacion habitacion = (Habitacion)diccHabitaciones[i][1];
                        row[tieneJac] = habitacion.TieneJacuzzi;
                        row[esExt] = habitacion.EsExterior;
                        row[cantCamSimples] = habitacion.CantCamasSingles;
                        row[cantCamDobles] = habitacion.CantCamasDobles;
                        row[precio] = habitacion.Precio.MontoDolares;
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
                                boundfield.ControlStyle.Width = Unit.Pixel(40);
                                grid_view_habitaciones.Columns.Add(boundfield);
                            }
                            else
                            {
                                CheckBoxField checkbox = new CheckBoxField();
                                checkbox.DataField = dc.ColumnName;
                                checkbox.HeaderText = dc.ColumnName;
                                checkbox.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                                grid_view_habitaciones.Columns.Add(checkbox);
                            }
                            Session["dataColumns"] = table.Columns;
                        }
                    }


                    grid_view_habitaciones.DataSource = table;
                    grid_view_habitaciones.DataBind();

                }
            }
        }
    }
}