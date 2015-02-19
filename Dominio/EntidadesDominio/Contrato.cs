using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    public class Contrato
    {
        #region atributos
        int id;
        static int ultId;
        int diasAlquilados;
        int cantidadPasajeros;
        Servicio servicio;
        #endregion

        #region propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public static int UltId
        {
            get { return Contrato.ultId; }
            set { Contrato.ultId = value; }
        }

        public int DiasAlquilados
        {
            get { return diasAlquilados; }
            set { diasAlquilados = value; }
        }

        public int CantidadPasajeros
        {
            get { return cantidadPasajeros; }
            set { cantidadPasajeros = value; }
        }

        public Servicio Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }

        #endregion
    }
}
