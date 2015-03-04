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
        bool expirada;
        decimal precioPesos;
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

        public bool Expirada
        {
            get { return expirada; }
            set { expirada = value; }
        }

        public decimal PrecioPesos
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

        public Reserva()
        {
            UltId++;
            this.Id = UltId;
            this.Expirada = false;
        }

        public int CompareTo(Reserva other)
        {
            if (this.PrecioPesos < other.PrecioPesos)
                return +1;
            else if (this.PrecioPesos > other.PrecioPesos)
                return -1;
            else
                return 0;
        }

        public void AgregarContrato(Servicio pServicio, int pDias, int pCant)
        {
            Contrato contrato = new Contrato();
            contrato.DiasAlquilados = pDias;
            contrato.CantidadPasajeros = pCant;

            contrato.Servicio = pServicio;

            this.Contratos.Add(contrato);
        }

        public void AgregarHabitacion(Habitacion pHab)
        {
            if (this.Habitaciones == null) this.Habitaciones = new List<Habitacion>();
            this.Habitaciones.Add(pHab);
        }

        public Precio CalcularPrecio()
        {
            Type tipo = Habitaciones[0].GetType(); 
            decimal pTot = 0M;
            if (tipo == typeof(Estandar)){
                foreach (Estandar Est in this.Habitaciones){

                    pTot += Est.CalcularPrecioTotal().MontoDolares;
                }
            }
            else if (tipo == typeof(Suite)){
                foreach (Suite Su in this.Habitaciones){

                    pTot += Su.CalcularPrecioTotal().MontoDolares;
                }
            }

            Precio tot = new Precio(pTot);

            return tot;
        }
    }
}
