using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.ServiciosDominio;
using Dominio.EntidadesDominio;
using Dominio.Utilidades;


namespace WebPruebas
{
    public partial class Default : System.Web.UI.Page
    {
        Sistema elSistema = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("Se agregaron " + elSistema.Habitaciones.Count + " Habitaciones");
            //Response.Write("Se agregaron " + elSistema.Servicios.Count + " Servicios");
            if (!IsPostBack)
            {
                drp_Pais.DataSource = ListaPaises.llenarPaises();
                drp_Pais.DataBind();
                drp_Pais.Items.Insert(0, "Seleccionar");
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Pasajero p = elSistema.BuscarPasajeroPorDocPais(int.Parse(txt_documento.Text), drp_Pais.SelectedValue);
            int resultado;
            if(int.TryParse(txt_documento.Text, out resultado)) 
            {

            }
            if (!Object.ReferenceEquals(null, p))
            {
                Response.Redirect("ModificarUsuario.aspx?modo=0"); // 0 modificar, 1 nuevo
            }
            else
            {
                Response.Redirect("ModificarUsuario.aspx?modo=1"); // 0 modificar, 1 nuevo
            }
            
        }
    }
}