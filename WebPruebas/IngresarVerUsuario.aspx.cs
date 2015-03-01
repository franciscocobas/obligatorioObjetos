﻿using System;
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
using System.Web.Security;
using WebPruebas;


namespace WebPruebas
{
    public partial class ModificarUsuario : System.Web.UI.Page
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
                LinkButton1.Visible = true;
                Dominio.EntidadesDominio.Pasajero p = elSistema.BuscarPasajeroPorDocPais(int_doc, pais);
                
                enableDisableFields(false);
                h1_inputTitle.Visible = false; // "Ingresar datos pasajero"
                h1_editTitle.Visible = true; //"Ver datos"
                h1_editTitle.InnerText = "Datos del pasajero";
                titulo.Text = "Datos Pasajero";

                txt_documento2.Text = doc;
                drp_Pais2.Items.FindByValue(pais).Selected = true;
                txt_nombre2.Text = p.Nombre;
                txt_dir1.Text = p.Direccion.CalleNro;
                txt_dir2.Text = p.Direccion.DirAdicional;
                txt_ciudad2.Text = p.Direccion.Ciudad;
                txt_dptoProv2.Text = p.Direccion.DptoProvincia;
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
            Page.Validate("expressionsIngr");

            if (Page.IsValid)
            {
                string doc = Request.QueryString["doc"];
                string pais = Request.QueryString["pais"];
                int int_doc = int.Parse(doc);

                if (Request.QueryString["modo"] == "0") // usuario existente
                {
                    Session["Pasajero"] = elSistema.BuscarPasajeroPorDocPais(int_doc, pais);
                    Response.Redirect("listarHabitaciones.aspx?pDoc=" + doc + "&pPais=" + pais);
                }

                else // usuario nuevo, validado
                {
                    elSistema.CrearPasajero(int_doc, pais, txt_nombre2.Text, new Direccion(txt_dir1.Text, txt_dir2.Text, txt_ciudad2.Text, txt_dptoProv2.Text, txt_CP.Text, drp_paisResid.SelectedValue));
                    Session["Pasajero"] = elSistema.BuscarPasajeroPorDocPais(int_doc, pais);
                    Response.Redirect("listarHabitaciones.aspxp?Doc=" + doc + "&pPais=" + pais);
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
            txt_nombre2.Enabled = status;
            txt_dir1.Enabled = status;
            txt_dir2.Enabled = status;
            txt_ciudad2.Enabled = status;
            txt_dptoProv2.Enabled = status;
            drp_paisResid.Enabled = status;
            txt_CP.Enabled = status;

        }

        protected void Ver_Reservas(object sender, EventArgs e)
        {
            Response.Redirect("ListarReservasPasaj.aspx?pDoc=" + txt_documento2.Text + "&pPais=" + drp_Pais2.SelectedValue);
        }
    }
}