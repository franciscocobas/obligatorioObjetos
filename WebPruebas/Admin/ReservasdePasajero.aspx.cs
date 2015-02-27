using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.ServiciosDominio;
using Dominio.EntidadesDominio;

namespace WebPruebas.Admin
{
    public partial class ReservasdePasajero : System.Web.UI.Page
    {
        Sistema elsistema = Sistema.Instancia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> listaUnicos = new List<string>();

                for (int i = 0; i < elsistema.Pasajeros.Count - 1; i++)
                {
                    for (int j = i + 1; j < elsistema.Pasajeros.Count; j++)
                    {
                        if (elsistema.Pasajeros[i].Documento.Equals(elsistema.Pasajeros[j].Documento))
                        {
                            listaUnicos.Add(elsistema.Pasajeros[i].Documento.ToString());
                        }
                    } 
                }
                docPasajero.DataSource = listaUnicos;
                docPasajero.DataBind();
                docPasajero.Items.Insert(0, "Seleccionar");
            }

        }

        protected void showCountryforDocs(object sender, EventArgs e)
        {
            if (docPasajero.SelectedIndex != 0)
            {
                List<string> listaSusPaises = new List<string>();

                for (int i = 0; i < elsistema.Pasajeros.Count; i++)
                {
                    if (elsistema.Pasajeros[i].Documento.ToString() == docPasajero.SelectedValue)
                    {
                        listaSusPaises.Add(elsistema.Pasajeros[i].PaisDocumento.ToString());
                    }
                }
                listaSusPaises.Sort();
                paisPasajero.DataSource = listaSusPaises;
                paisPasajero.DataBind();
                paisPasajero.Items.Insert(0, "Seleccionar");
            }
        }

        protected void buscar_Reservas_Pasajero(object sender, EventArgs e)
        {   
            //string doc = docPasajero.SelectedValue;
            //string paisDoc = paisPasajero.SelectedValue;

            //Pasajero p = elsistema.BuscarPasajeroPorDocPais(int.Parse(doc), paisDoc);

            //List<Reserva> listaRes = new List<Reserva>();
            //listaRes = p.listaReservas;
        }
    }
}