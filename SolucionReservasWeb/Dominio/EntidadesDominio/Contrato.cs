using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    class Contrato
    {
        #region atributos
        int diasAlquilados;
        int cantidadPasajeros;
        Servicio servicio;

        #endregion

        #region propiedades
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
        #endregion
    }
}
