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
        const int minSize = 8;
        const int maxSize = 10;

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
        
        public override bool Equals(object obj)
        {
            Pasajero p = obj as Pasajero;
            if (obj == null) return false;
            return this.id == p.id;
        }

        public override int GetHashCode() /// agregué esto porque me decia: Warning1 'Dominio.EntidadesDominio.Habitacion' overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #region Validacion

        public static bool valSizeDocumento(string pDoc)
        {
            return pDoc.Length <= maxSize && pDoc.Length >= minSize;
        }

        #endregion
    }
}
