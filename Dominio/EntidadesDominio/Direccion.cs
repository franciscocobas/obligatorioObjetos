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
    }
}
