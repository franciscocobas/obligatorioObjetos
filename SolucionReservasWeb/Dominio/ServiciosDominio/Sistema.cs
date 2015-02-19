using System;
using System.Collections.Generic;
using Dominio.Utilidades;
using Dominio.EntidadesDominio;
namespace Dominio.ServiciosDominio
{

    public class Sistema
    {
        #region Singleton

        private readonly static Sistema instancia = new Sistema();
        
        private Sistema()
        {

            Inicializar();

        }
        public static Sistema Instancia
        {
            get { return instancia; }
        }
        
        #endregion

        #region Listas
        public List<Habitacion> Habitaciones { get; private set; }
        public List<Servicio> Servicios { get; private set; }
        public List<Pasajero> Pasajeros { get; private set; }
        public List<Reserva> Reservas { get; private set; }
        #endregion

        # region Carga de datos iniciales
    
        void Inicializar()
        {

            ConfigurarParametros();
            CargarHabitacionesPrueba();
            CargarServiciosPrueba();

        }

        private void ConfigurarParametros() 
        {
            Estandar.PrecioBasicoXCama = new Precio(89);
            CotizacionDolar.Instancia.ActualizarPrecios(23.40M, 20.50M);//M es el sufijo para decimal

        }

        private void CargarServiciosPrueba()
        {
            AgregarServicio(new Servicio("Canoas", new Precio(180M), 75, 89));
            AgregarServicio(new Servicio("Pensión Completa", new Precio(3500M), 20, 89));

        }

        private void CargarHabitacionesPrueba()
        {
            AgregarHabitacion(CrearHabitacionEstandar(108, false, true, 2, 1));
            AgregarHabitacion(CrearHabitacionSuite(109, true, true, 0, 1, new Precio(400)));
            AgregarHabitacion(CrearHabitacionSuite(110, true, true, 0, 1, new Precio(250.0M)));

        }
       
        #endregion

        #region Habitaciones
        
        public Estandar CrearHabitacionEstandar(int numero, bool jacuzzi, bool exterior, int camasSimples, int camasDobles)
        {
            return new Estandar(numero, jacuzzi, exterior, camasSimples, camasDobles);
        }
        public Suite CrearHabitacionSuite(int numero, bool jacuzzi, bool exterior, int camasSimples, int camasDobles, Precio precioBase)
        {
            return new Suite(numero, jacuzzi, exterior, camasSimples, camasDobles, precioBase);
        }
        public void AgregarHabitacion(Habitacion nuevaHab)
        {
            if (this.Habitaciones == null) this.Habitaciones = new List<Habitacion>();
            this.Habitaciones.Add(nuevaHab);

        }
        
        #endregion
        
        #region  Servicios

        public void AgregarServicio(Servicio s) // no hay metodo CrearServicio() !! esta bien??
        {
            if (this.Servicios == null) this.Servicios = new List<Servicio>();
            this.Servicios.Add(s);
        }
        
        #endregion
       
        #region Otros

        public List<string> listaPaises()
        {
            ListaPaises.llenarPaises();
            return ListaPaises.Nombres;
        }

        //public List<string> listaCiudades()
        //{
        //    ListaCiudades.llenarCiudades();
        //    return ListaCiudades.Nombres;
        //}

        #endregion

        //public void AgregarReserva(Reserva res)
        //{
        //    if (this.Reservas == null) this.Reservas = new List<Reserva>();
        //    this.Reservas.Add(res);
        //}
    }
}
