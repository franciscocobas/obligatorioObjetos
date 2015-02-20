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
        public List<Administrativo> Administrativos { get; private set; }

        #endregion
        # region Carga de datos iniciales
    
        void Inicializar()
        {

            ConfigurarParametros();
            CargarHabitacionesPrueba();
            CargarServiciosPrueba();
            Pasajero pas = new Pasajero(123, "Uruguay", "Pasajero Pasajero", new Direccion());
            if (this.Pasajeros == null) this.Pasajeros = new List<Pasajero>();
            this.Pasajeros.Add(pas);

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
        private void CargarAdministrativoPrueba()
        {
            AgregarAdministrativo(CrearAdministrativo("admin", "admin", "Administrativo"));
        }
        #endregion
        #region Administrativos
        public Administrativo CrearAdministrativo(string pUsuario, string pPassword, string pNombre)
        {
            return new Administrativo(pUsuario, pPassword, pNombre);
        }
        public void AgregarAdministrativo (Administrativo pAdmin)
        {
            if (this.Administrativos == null) this.Administrativos = new List<Administrativo>();
            this.Administrativos.Add(pAdmin);
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

        public List<Habitacion> ObtenerHabitacionesDisponiblesXFecha(DateTime pfechaDesde, DateTime pfechaHasta)
        {
            // metodo a implementar.
            return new List<Habitacion>();
            
        }

        public List<Habitacion> ObtenerHabitacionesDisponiblesXTipo(DateTime pFechaDesde, DateTime pFechaHasta, String pTipo)
        {
            List<Habitacion> habitacionesDispXTipo = new List<Habitacion>();
            List<Habitacion> habitacionesDisponibles = ObtenerHabitacionesDisponiblesXFecha(pFechaDesde, pFechaHasta);

            // Filtro por tipo
            foreach (Habitacion habitacion in habitacionesDisponibles)
            {
                Type tipoHabitacion = habitacion.GetType();
                if (tipoHabitacion.Name == pTipo)
                {
                    habitacionesDispXTipo.Add(habitacion);
                }
            }
            return habitacionesDispXTipo;
        }
        
        public List<Habitacion> MostrarHabitNoDisponibles(List<Habitacion> pHabitaciones, Precio pPrecio, DateTime pFechaDesde, DateTime pFechaHasta)
        {
            // metodo a implementar
            return new List<Habitacion>();
        }

        public int ObtenerTotalPasajeros(List<Habitacion> pHabitaciones)
        {
            // metodo a implementar
            return 0;
        }
        public Precio MostrarTarifaHabitaciones(List<Habitacion> pHabitaciones)
        {
            // metodo a implementar
            return new Precio(0M);
        }
        #endregion
        #region  Servicios
        public void AgregarServicio(Servicio s)
        {
            if (this.Servicios == null) this.Servicios = new List<Servicio>();
            this.Servicios.Add(s);
        }
        #endregion

        #region Pasajeros
        public Pasajero CrearPasajero(int pDocumento, string pPaisDoc, string pNombre, Direccion pDireccion)
        {
            return new Pasajero(pDocumento, pPaisDoc, pNombre, pDireccion);
        }
        public Pasajero ModificarPasajero(int pDocumento, string pPaisDoc, string pNombre, Direccion pDireccion)
        {
            Pasajero pasajeroAModificar = BuscarPasajeroPorDocPais(pDocumento, pPaisDoc);
            pasajeroAModificar.Documento = pDocumento;
            pasajeroAModificar.PaisDocumento = pPaisDoc;
            pasajeroAModificar.Nombre = pNombre;
            pasajeroAModificar.Direccion = pDireccion;

            return pasajeroAModificar;
        }
        public Pasajero BuscarPasajeroPorDocPais(int pDocumento, string pPaisDocumento)
        {
            Pasajero pasajeroEncontrado = null;
            foreach (Pasajero p in this.Pasajeros)
            {
                if (p.Documento == pDocumento && p.PaisDocumento == pPaisDocumento)
                {
                    pasajeroEncontrado = p;
                }
            }
            return pasajeroEncontrado;
        }
        #endregion

        #region Reservas
        public Reserva CrearReserva(DateTime pFechaDesde, DateTime pFechaHasta, int pCantMayores, int pCantMenores, List<int> pHabitaciones)
        {
            // metodo a implementar
            return new Reserva();
        }

        public void CancelarReserva(int pIdPasajero, int pIdReserva)
        {
            // metodo a implementar
        }

        #endregion

        #region Otros

        public List<string> listaPaises()
        {
            ListaPaises.llenarPaises();
            return ListaPaises.Nombres;
        }

        public Precio MostrarDineroRecaudadoEntreFechas(DateTime pDesde, DateTime pHasta)
        {
            // Método a implementar
            return new Precio(0M);
        }

        public List<Reserva> RecuperarReservasActivas(int pIdPasajero)
        {
            // Metodo a implementar
            return new List<Reserva>();
        }

        #endregion

    }
}
