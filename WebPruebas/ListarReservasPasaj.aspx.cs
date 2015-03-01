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
            GridView1.DataSource = reservasActivas;
            GridView1.DataBind();
        }

        protected void Volver(object sender, EventArgs e)
        {
            string doc = Request.QueryString["pDoc"];
            string pais = Request.QueryString["pPais"];
            Response.Redirect("IngresarVerUsuario.aspx?modo=" + 0 + "&doc=" + doc + "&pais=" + pais);
        }
    }
}