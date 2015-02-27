using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;


namespace WebPruebas
{
    public partial class MasterAdmin : System.Web.UI.MasterPage
    {
        CotizacionDolar cotiza = CotizacionDolar.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                txt_compra.Text = cotiza.PrecioCompra.ToString();
                txt_venta.Text = cotiza.PrecioVenta.ToString();
            }
        }

        protected void LnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("Admin");
            Response.Redirect("loginAdmin.aspx");

        }

        protected void Actualizar_Cotizacion(object sender, EventArgs e)
        {
            if (btn_commit.Text == "Actualizar")
            {
                txt_compra.Enabled = true;
                txt_venta.Enabled = true;
                btn_commit.Text = "Confirmar";
            }
            else
            {
                Sistema elsistema = Sistema.Instancia;
                decimal decCompra;
                decimal decVenta;
                bool valido = elsistema.ValidarPrecios(txt_venta.Text, txt_compra.Text, out decVenta, out decCompra);
                if (valido)
                {
                    txt_compra.Enabled = false;
                    txt_venta.Enabled = false;
                    cotiza.ActualizarPrecios(decVenta, decCompra);
                    txt_compra.Text = cotiza.PrecioCompra.ToString();
                    txt_venta.Text = cotiza.PrecioVenta.ToString();                   
                    btn_commit.Text = "Actualizar";

                }
                else
                {
                    div_errorCotiz.InnerHtml = "<p style='color: #FF0000; font-size: 13px; margin:0px; font-family: &quot;Courier New&quot;, Courier, monospace'>Ingrese sólo decimales</p>";
                }
            }
        }
    }
}