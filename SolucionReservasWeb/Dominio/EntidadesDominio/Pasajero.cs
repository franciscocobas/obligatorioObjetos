using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    class Pasajero
    {
        #region Atributos
        int id;
        static int ultId;
        int documento;
        string paisDocumento;
        string nombre;
        string direccion;
        string ciudad;
        string departamento;
        int codigoPostal;
        string pais;
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

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public string Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public int CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public int Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        #endregion
    }
}
