using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    public class Pasajero
    {
        #region Atributos
        int id;
        static int ultId;
        int documento;
        string paisDocumento;
        string nombre;
        Direccion direccion;
        #endregion

        #region Propiedades
        public static int UltId
        {
            get { return Pasajero.ultId; }
            set { Pasajero.ultId = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string PaisDocumento
        {
            get { return paisDocumento; }
            set { paisDocumento = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public int Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        #endregion

        public Pasajero(int pDocumento, string pPaisDoc, string pNombre, Direccion pDireccion)
        {
            this.Documento = pDocumento;
            this.PaisDocumento = pPaisDoc;
            this.Nombre = pNombre;
            this.Direccion = pDireccion;
        }
    }
}
