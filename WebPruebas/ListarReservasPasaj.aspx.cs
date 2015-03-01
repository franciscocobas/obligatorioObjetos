using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.ServiciosDominio;
using Dominio.EntidadesDominio;
using System.Data;

namespace WebPruebas
{
    public partial class ListarReservasPasaj : System.Web.UI.Page
    {
        Sistema elsistema = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            int pDoc = int.Parse(Request.QueryString["pDoc"]);
            string pPais = Request.QueryString["pPais"];
            Pasajero p = elsistema.BuscarPasajeroPorDocPais(pDoc, pPais);

            titulo.InnerText = "Reservas activas de " + p.Nombre;

            List<Reserva> reservasActivas = new List<Reserva>();
            reservasActivas = elsistema.RecuperarReservasActivas(p);

            GridView1.AutoGenerateColumns = false;

            string nuHabit = "Cantidad de Habitaciones";
            string cantMen = "Cantidad de menores";
            string cantMayor = "Cantidad de Mayores";
            string tipo = "Tipo de habitaciones";
            string precio = "Precio (U$S)";
            string fDesde = "Desde";
            string fHasta = "Hasta";

            DataTable table = new DataTable();
            DataColumn columnNumHabit = new DataColumn(nuHabit, typeof(System.Int32));
            table.Columns.Add(columnNumHabit);
            DataColumn columnTipoHabit = new DataColumn(tipo, typeof(System.String));
            table.Columns.Add(columnTipoHabit);
            DataColumn columnMenores = new DataColumn(cantMen, typeof(System.Int32));
            table.Columns.Add(columnMenores);
            DataColumn columnMayores = new DataColumn(cantMayor, typeof(System.Int32));
            table.Columns.Add(columnMayores);
            DataColumn columnPrecio = new DataColumn(precio, typeof(System.Decimal));
            table.Columns.Add(columnPrecio);
            DataColumn columnDesde = new DataColumn(fDesde, typeof(System.DateTime));
            table.Columns.Add(columnDesde);
            DataColumn columnHasta = new DataColumn(fHasta, typeof(System.DateTime));
            table.Columns.Add(columnHasta);


            foreach (Reserva res in reservasActivas)
            {
                DataRow row = table.NewRow();
                
                foreach (Habitacion hab in res.Habitaciones){

                }
                row[columnNumHabit] = res.Habitaciones.Count;
                row[columnTipoHabit] = res.Habitaciones[0].GetType();
                row[columnMenores] = res.CantMenores;
                row[columnMayores] = res.CantMayores;
                row[columnDesde] = res.FechaDesde;
                row[columnHasta] = res.FechaHasta;
                row[precio] = res.PrecioPesos;
                table.Rows.Add(row);
            }

            foreach (DataColumn dc in table.Columns)
            {
                BoundField boundfield = new BoundField();
                boundfield.DataField = dc.ColumnName;
                boundfield.HeaderText = dc.ColumnName;
                boundfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns.Add(boundfield);
            }

            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}