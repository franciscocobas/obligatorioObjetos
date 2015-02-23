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
using System.ComponentModel.DataAnnotations;

namespace WebPruebas
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        Sistema elSistema = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            string doc = Request.QueryString["doc"];
            int int_doc = int.Parse(doc);
            string pais = Request.QueryString["pais"];   
            
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
                Pasajero p = elSistema.BuscarPasajeroPorDocPais(int_doc, pais);
                
                enableDisableFields(false);
                h1_inputTitle.Visible = false; // "Ingresar datos pasajero"
                h1_editTitle.Visible = true; //"Ver datos"
                h1_editTitle.InnerText = "Datos del pasajero";
                titulo.Text = "Datos Pasajero";

                txt_documento2.Text = doc;
                drp_Pais2.Items.FindByValue(pais).Selected = true;
                txt_nombre.Text = p.Nombre;
                txt_dir1.Text = p.Direccion.CalleNro;
                txt_dir2.Text = p.Direccion.DirAdicional;
                txt_ciudad.Text = p.Direccion.Ciudad;
                txt_dptoProv.Text = p.Direccion.DptoProvincia;
                drp_paisResid.Items.FindByValue(p.Direccion.Pais).Selected = true;
                txt_CP.Text = p.Direccion.CodigoPostal;

                // sólo ver datos

            }
            else
            {
                titulo.Text = "Ingresar Datos Pasajero";
                enableDisableFields(true);
                h1_editTitle.Visible = false;
                h1_inputTitle.Visible = true;
                txt_documento2.Text = doc;
                drp_Pais2.Items.FindByValue(pais).Selected = true;
                btn_modifDato.Visible = false;

                // registrarse: tomar datos y crear nuevo pasajero (on click "hacer reserva")
            }
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            // ver datos no protegidos y modificarlos. Guardar nuevos datos
            enableDisableFields(true);

            Response.Redirect("ModificarUsuario.aspx?doc=" + txt_documento2.Text + "&pais=" + drp_Pais2.SelectedValue);
           // otra pagina porque tuve problemas que no me dejaba modificar, hasta que encontre que era. Se puede volver a traer todo a una misma pag
        }

        protected void Reserva_Click(object sender, EventArgs e)
        {
            string doc = Request.QueryString["doc"];
            int int_doc = int.Parse(doc);
            string pais = Request.QueryString["pais"];
            if (Request.QueryString["modo"] == "0") // usuario existente
            {
                Response.Redirect("Reserva.aspx?doc=" + txt_documento2.Text + "&pais=" + drp_Pais2.SelectedValue); 
            }
            else // usuario nuevo, validado
            {
                if (IsFilled(txt_nombre.Text) && IsFilled(txt_dir1.Text) && IsFilled(txt_ciudad.Text) && IsFilled(txt_dptoProv.Text) && IsFilled(txt_CP.Text) && drp_paisResid.SelectedIndex != 0)
                {
                    elSistema.AgregarPasajero(elSistema.CrearPasajero(int_doc, pais, txt_nombre.Text, new Direccion(txt_dir1.Text, txt_dir2.Text, txt_ciudad.Text, txt_dptoProv.Text, txt_CP.Text, drp_paisResid.SelectedValue)));
                    Response.Redirect("Reserva.aspx?doc=" + txt_documento2.Text + "&pais=" + drp_Pais2.SelectedValue); 

                }
            }

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private void enableDisableFields(bool _status) // true = enable; false = disable
        {
            bool status = _status;
            txt_documento2.Enabled = false;
            drp_Pais2.Enabled = false;
            txt_nombre.Enabled = status;
            txt_dir1.Enabled = status;
            txt_dir2.Enabled = status;
            txt_ciudad.Enabled = status;
            txt_dptoProv.Enabled = status;
            drp_paisResid.Enabled = status;
            txt_CP.Enabled = status;

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