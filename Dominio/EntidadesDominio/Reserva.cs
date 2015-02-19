using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.EntidadesDominio;

namespace Dominio.EntidadesDominio
{
    public class Reserva : IComparable<Reserva>
    {
        #region atributos
        int id;
        static int ultId;
        bool activa;
        double precioPesos;
        DateTime fechaDesde;
        DateTime fechaHasta;
        int cantMenores;
        int cantMayores;
        public List<Habitacion> Habitaciones { get; private set; }
        public List<Contrato> Contratos { get; private set; }

        #endregion

        #region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public static int UltId
        {
            get { return Reserva.ultId; }
            set { Reserva.ultId = value; }
        }
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

        public int CantMayores
        {
            get { return cantMayores; }
            set { cantMayores = value; }
        }
        #endregion

        public int CompareTo(Reserva other)
        {
            throw new NotImplementedException();
        }

        public void AgregarContrato(Servicio pServicio, int pDias, int pCant)
        {
            // metodo a implementar
        }

        public void AgregarHabitacion(int pId)
        {
            // metodo a implementar
        }

        public Precio CalcularPrecio()
        {
            // metodo a implementar
            return new Precio(0M);
        }
    }
}
