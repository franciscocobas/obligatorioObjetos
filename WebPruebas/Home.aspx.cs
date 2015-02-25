using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using Dominio.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPruebas
{
    public partial class Default : System.Web.UI.Page
    {
        Sistema elSistema = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.WebForms;
            ScriptResourceDefinition jQuery = new ScriptResourceDefinition();
            jQuery.Path = "~/scripts/jquery-2.1.3.min.js";
            jQuery.DebugPath = "~/scripts/jquery-2.1.3.js";
            jQuery.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.min.js";
            jQuery.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery); 

            if (!IsPostBack)
            {
                drp_Pais.DataSource = ListaPaises.llenarPaises();
                drp_Pais.DataBind();
                drp_Pais.Items.Insert(0, "Seleccionar");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            string doc = txt_documento.Text;
            string pais = drp_Pais.SelectedValue;
            string alert;
            Pasajero p = elSistema.existePasajero(doc, pais, out alert);
            
            if (p != null)
            {
                Response.Redirect("IngresarVerUsuario.aspx?modo=0&doc=" + doc + "&pais=" + pais); // 0 modificar, 1 nuevo
            }
            else
            {
                if (alert == null){
                    Response.Redirect("IngresarVerUsuario.aspx?modo=1&doc=" + doc + "&pais=" + pais); // 0 modificar, 1 nuevo
                }
                else
                {
                    div_errorMessageDiv.InnerHtml = "<p style='color: #FF0000; font-size: 12px; margin:0px; font-family: &quot;Courier New&quot;, Courier, monospace'>"+ alert +"</p>";
                }
            }
        }
    }
}