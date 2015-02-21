using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio.EntidadesDominio;
using Dominio.ServiciosDominio;
using Dominio.Utilidades;

namespace WebPruebas
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        Sistema elSistema = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drp_Pais2.DataSource = ListaPaises.llenarPaises();
                drp_Pais2.DataBind();
                drp_Pais2.Items.Insert(0, "Seleccionar");
                drp_paisResid.DataSource = ListaPaises.llenarPaises();
                drp_paisResid.DataBind();
                drp_paisResid.Items.Insert(0, "Seleccionar");
            }

            if (Request.QueryString["modo"] == "0")
            {
                string doc = Request.QueryString["doc"];
                int int_doc = int.Parse(doc);
                string pais = Request.QueryString["pais"];   
                Pasajero p = elSistema.BuscarPasajeroPorDocPais(int_doc, pais);

                titulo.Text = "Datos Pasajero";
                h1_editTitle.Visible = true;
                h1_inputTitle.Visible = false;
                txt_documento2.Text = doc;
                txt_documento2.Enabled = false;
                drp_Pais2.Items.FindByValue(pais).Selected = true;
                drp_Pais2.Enabled = false;
                txt_nombre.Text = p.Nombre;
                txt_nombre.Enabled = false;
                txt_dir1.Text = p.Direccion.CalleNro;
                txt_dir1.Enabled = false;
                txt_dir2.Text = p.Direccion.DirAdicional;
                txt_dir2.Enabled = false;
                txt_ciudad.Text = p.Direccion.Ciudad;
                txt_ciudad.Enabled = false;
                txt_dptoProv.Text = p.Direccion.DptoProvincia;
                txt_dptoProv.Enabled = false;
                drp_paisResid.Items.FindByValue(p.Direccion.Pais);
                drp_paisResid.Enabled = false;
                txt_CP.Text = p.Direccion.CodigoPostal;
                txt_CP.Enabled = false;

                

            }
            else
            {
                titulo.Text = "Ingresar Datos Pasajero";
                h1_editTitle.Visible = false;
                h1_inputTitle.Visible = true;
            }
        }
    }
}