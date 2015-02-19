using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDominio;

namespace Dominio.EntidadesDominio
{
    class Reserva
    {
        #region atributos
        int id;
        DateTime fechaDesde;
        DateTime fechaHasta;
        int cantMenores;
        double precioPesos;
        bool activa;
        public List<Habitacion> Habitaciones { get; private set; }
        public List<Contrato> Contratos { get; private set; }

        #endregion

        #region Propiedades
        public bool Activa
        {
            get { return activa; }
            set { activa = value; }
        }

        public double PrecioPesos
        {
            get { return precioPesos; }
            set { precioPesos = value; }
        }

        public DateTime FechaDesde
        {
            get { return fechaDesde; }
            set { fechaDesde = value; }
        }

        public DateTime FechaHasta
        {
            get { return fechaHasta; }
            set { fechaHasta = value; }
        }

        public int CantMenores
        {
            get { return cantMenores; }
            set { cantMenores = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
    }
}
