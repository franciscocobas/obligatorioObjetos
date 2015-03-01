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

namespace WebPruebas
{
    public partial class ModificarUsuario1 : System.Web.UI.Page
    {
        Sistema elSistema = Sistema.Instancia;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string doc = Request.QueryString["doc"];
            int int_doc = int.Parse(doc);
            string pais = Request.QueryString["pais"];

            LinkButton1.Visible = true;

            if (!IsPostBack)
            {
                drp_Pais2.DataSource = ListaPaises.llenarPaises();
                drp_Pais2.DataBind();
                drp_Pais2.Items.Insert(0, "Seleccionar");
                drp_paisResid.DataSource = ListaPaises.llenarPaises();
                drp_paisResid.DataBind();
                drp_paisResid.Items.Insert(0, "Seleccionar");

                Dominio.EntidadesDominio.Pasajero p = elSistema.BuscarPasajeroPorDocPais(int_doc, pais);

                txt_documento2.Text = doc;
                txt_documento2.Enabled = false;
                drp_Pais2.Items.FindByValue(pais).Selected = true;
                drp_Pais2.Enabled = false;
                txt_nombre.Text = p.Nombre;
                txt_dir1.Text = p.Direccion.CalleNro;
                txt_dir2.Text = p.Direccion.DirAdicional;
                txt_ciudad.Text = p.Direccion.Ciudad;
                txt_dptoProv.Text = p.Direccion.DptoProvincia;
                drp_paisResid.Items.FindByValue(p.Direccion.Pais).Selected = true;
                txt_CP.Text = p.Direccion.CodigoPostal;
            }

            titulo.Text = "Datos Pasajero";
        }

        protected void ReservaModif_Click(object sender, EventArgs e)
        {
            Page.Validate("expressions");

            if (Page.IsValid)
            {
                string doc = Request.QueryString["doc"];
                int int_doc = int.Parse(doc);
                string pais = Request.QueryString["pais"];
                Direccion nuevaDir = elSistema.ModificarDireccion(int_doc, pais, txt_dir1.Text, txt_dir2.Text, txt_ciudad.Text, txt_dptoProv.Text, txt_CP.Text, drp_paisResid.SelectedValue);
                //aca puedo cambiar new Direction por un metodo que sea modificar direccion?
                Dominio.EntidadesDominio.Pasajero p = elSistema.ModificarPasajero(int_doc, pais, txt_nombre.Text, nuevaDir);
                if (p != null){
                    Session["Pasajero"] = p;
                    Response.Redirect("listarHabitaciones.aspx?pDoc=" + doc + "&pPais=" + pais);
                }
            }
            
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void Ver_Reservas(object sender, EventArgs e)
        {
            Response.Redirect("ListarReservasPasaj.aspx?pDoc=" + txt_documento2.Text + "&pPais=" + drp_Pais2.SelectedValue);
        }
    }
}