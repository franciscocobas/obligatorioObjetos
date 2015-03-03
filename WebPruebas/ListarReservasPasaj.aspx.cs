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
            if (btn_eliminar.Text == "Confirmar eliminación")
            {
                div_instruccionEliminar.Visible = true;

            }
            else
            {
                div_instruccionEliminar.Visible = false;

            }
            cargarTabla();

        }

        protected void Volver(object sender, EventArgs e)
        {
            string doc = Request.QueryString["pDoc"];
            string pais = Request.QueryString["pPais"];
            Response.Redirect("IngresarVerUsuario.aspx?modo=" + 0 + "&doc=" + doc + "&pais=" + pais);

        }

        protected void cancelar_Reservas(object sender, EventArgs e)
        {
            string doc = Request.QueryString["pDoc"];
            string pais = Request.QueryString["pPais"];

            if (btn_eliminar.Text == "Cancelar reservas")
            {
                div_instruccionEliminar.Visible = true;
                GridView1.Columns[0].Visible = true;
                btn_eliminar.Text = "Confirmar eliminación";
            }
            else if (btn_eliminar.Text == "Confirmar eliminación"){
                
                GridView1.Columns[0].Visible = false;

                string txtEventId = "";
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    RadioButton rb = (GridView1.Rows[i].FindControl("CheckBox1")) as RadioButton;
                    if (rb.Checked == true)
                    {
                        txtEventId = GridView1.Rows[i].Cells[1].Text;
                    }
                }

                if (txtEventId != "")
                {
                    elsistema.CancelarReserva(int.Parse(doc), pais, int.Parse(txtEventId));
                    p_instrucc.InnerText = "Su reserva ha sido eliminada";
                    btn_eliminar.Enabled = false;
                }
            }
        }

        protected void cargarTabla()
        {
            int pDoc = int.Parse(Request.QueryString["pDoc"]);
            string pPais = Request.QueryString["pPais"];
            Pasajero p = elsistema.BuscarPasajeroPorDocPais(pDoc, pPais);
            titulo.InnerText = "Reservas activas de " + p.Nombre;
            List<Reserva> reservasActivas = new List<Reserva>();
            reservasActivas = elsistema.RecuperarReservasActivas(p);

            if (reservasActivas.Count == 0)
            {
                btn_eliminar.Visible = false;
                div_instruccionEliminar.Visible = true;
                p_instrucc.InnerText = "Usted no tiene actualmente reservas activas";
            }
            else
            {
                btn_eliminar.Visible = true;
            }

            GridView1.AutoGenerateColumns = false;

            if (!IsPostBack)
            {
                this.GridView1.DataSource = reservasActivas;
                this.GridView1.DataBind();
            }
        }


       
    }
}