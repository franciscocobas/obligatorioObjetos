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
            
            // "UnobtrusiveValidationMode requires a ScriptResourceMapping for 'jquery'. Please add a ScriptResourceMapping named jquery"
            ScriptResourceDefinition jQuery = new ScriptResourceDefinition();
            jQuery.Path = "~/scripts/jquery-2.1.3.min.js";
            jQuery.DebugPath = "~/scripts/jquery-2.1.3.js";
            jQuery.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.min.js";
            jQuery.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.1.3.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery); 

            //Response.Write("Se agregaron " + elSistema.Pasajeros.Count + " Pasajeros");
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
            int resultado;
            bool output = int.TryParse(txt_documento.Text, out resultado);
            Pasajero p = elSistema.BuscarPasajeroPorDocPais(resultado, drp_Pais.SelectedValue);
            
            if (!Object.ReferenceEquals(null, p))
            {
                Response.Redirect("IngresarVerUsuario.aspx?modo=0&doc=" + txt_documento.Text + "&pais=" + drp_Pais.SelectedValue); // 0 modificar, 1 nuevo
            }
            else
            {
                if (output) // true = input es int
                {
                    if (txt_documento.Text.Length <= 10 && txt_documento.Text.Length >= 8)
                    {
                        Response.Redirect("IngresarVerUsuario.aspx?modo=1&doc=" + txt_documento.Text + "&pais=" + drp_Pais.SelectedValue); // 0 modificar, 1 nuevo
                    }
                    else
                    {
                        div_errorMessageDiv.InnerHtml = "<p style='color: #FF0000; font-size: 12px; margin:0px; font-family: &quot;Courier New&quot;, Courier, monospace'>El número de documento debe tener 8-10 caracteres</p>";
                    }
                }
                else // false = output es str
                {
                    div_errorMessageDiv.InnerHtml = "<p style='color: #FF0000; font-size: 12px; margin:0px; font-family: &quot;Courier New&quot;, Courier, monospace'>El documento debe estar compuesto únicamente por números</p>";
                }
            }
        }

        private bool IsFilled(string s)
        {
            if (s != "")
            { return true; }
            else
            { return false; }
        }
    }
}