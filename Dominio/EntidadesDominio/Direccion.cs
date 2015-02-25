using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    public class Direccion
    {
        int id;
        static int ultId;
        string calleNro;
        string dirAdicional;
        string ciudad;
        string dptoProvincia;
        string codigoPostal;
        string pais; // agregado, no estaba en el original, pero puede ser diferente de el pais emisor del documento

        #region propiedades

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public static int UltId
        {
            get { return Direccion.ultId; }
            set { Direccion.ultId = value; }
        }

        public string CalleNro
        {
            get { return calleNro; }
            set { calleNro = value; }
        }

        public string DirAdicional
        {
            get { return dirAdicional; }
            set { dirAdicional = value; }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public string DptoProvincia
        {
            get { return dptoProvincia; }
            set { dptoProvincia = value; }
        }

        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        #endregion

        public Direccion ()
        {
            this.id = ultId + 1;
            Direccion.ultId = this.id;
        }

        public Direccion(string _calleNro, string _dirAdicional, string _ciudad, string _dptoProvinc, string _cPostal, string _pais)
        {
            this.id = ultId + 1;
            Direccion.ultId = this.id;
            this.calleNro = _calleNro;
            this.dirAdicional = _dirAdicional;
            this.ciudad = _ciudad;
            this.dptoProvincia = _dptoProvinc;
            this.codigoPostal = _cPostal;
            this.pais = _pais;

        }
    }
}
