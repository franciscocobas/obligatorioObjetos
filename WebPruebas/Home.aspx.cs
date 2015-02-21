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
            //Response.Write("Se agregaron " + elSistema.Habitaciones.Count + " Habitaciones");
            //Response.Write("Se agregaron " + elSistema.Servicios.Count + " Servicios");

            //// "UnobtrusiveValidationMode requires a ScriptResourceMapping for 'jquery'. Please add a ScriptResourceMapping named jquery"
            //string JQueryVer = "2.1.3";
            //ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            //{
            //    Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
            //    DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
            //    CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
            //    CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
            //    CdnSupportsSecureConnection = true,
            //    LoadSuccessExpression = "window.jQuery"
            //}
            //);
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
            
            // check field not null
            if (IsFilled (txt_documento.Text))
            {
                if (drp_Pais.SelectedIndex != 0)
                {
                    if (!Object.ReferenceEquals(null, p))
                    {
                        Response.Redirect("ModificarUsuario.aspx?modo=0&doc=" + txt_documento.Text + "&pais=" + drp_Pais.SelectedValue); // 0 modificar, 1 nuevo
                    }
                    else
                    {
                        if (output) // true = input es int
                        {
                            if (txt_documento.Text.Length <= 10 && txt_documento.Text.Length >= 8)
                            {
                                Response.Redirect("ModificarUsuario.aspx?modo=1&doc=" + txt_documento.Text + "&pais=" + drp_Pais.SelectedValue); // 0 modificar, 1 nuevo
                            }
                            else
                            {
                                div_errorMessageDiv.InnerHtml = "<p style='color: #FF0000; font-size: 16px; margin:0px; font-family: &quot;Courier New&quot;, Courier, monospace'>El número de documento debe tener 8-10 caracteres</p>";
                            }
                        }
                        else // false = output es str
                        {

                        }
                    }
                }
                else // sin país seleccionado ("Seleccionar")
                {
                    div_errorMessageDiv.InnerHtml = "<p style='color: #FF0000; font-size: 16px; margin:0px; font-family: &quot;Courier New&quot;, Courier, monospace'>Debe seleccionar un país de documento</p>";
                }
            }
            else if (!IsFilled(txt_documento.Text) || txt_documento.Text == "Documento")
            {
                div_errorMessageDiv.InnerHtml = "<p style='color: #FF0000; font-size: 16px; margin:0px; font-family: &quot;Courier New&quot;, Courier, monospace'>Debe ingresar un documento</p>";
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