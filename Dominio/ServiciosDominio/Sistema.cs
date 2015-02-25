using System;
using System.Collections.Generic;
using Dominio.Utilidades;
using Dominio.EntidadesDominio;
using System.Security.Policy;
using System.Reflection;


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
            CargarAdministrativoPrueba();
            //agregar pasajero se tiene que eliminar cuando se entregue??
            CrearPasajero(12345678, "Uruguay", "Pasajero Pasajero", new Direccion("SanMartin3384", "", "Montevideo", "Montevideo", "11710", "Uruguay"));
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
            AgregarAdmin("admin", "admin", "Administrativo");
        }

        #endregion

        #region Administrativos

        public Administrativo ValidarLogin(string usrname, string pass)
        {
            Administrativo usr = this.BuscarAdmin(usrname);
            bool login_true = false;

            if (usr != null)
                login_true = usr.loginCorrecto(usrname, pass);
            if (login_true)
                return usr;
            else
            {
                return null;
            }
        }

        private Administrativo BuscarAdmin(string usrnm)
        {
            Administrativo adminEncontrado = null;

            foreach (Administrativo a in this.Administrativos)
            {
                if (a.Usuario == usrnm)
                {
                    adminEncontrado = a;
                }
            }
            return adminEncontrado;

        }

        private bool ExisteAdmin(string usrnm)
        {
            return (this.BuscarAdmin(usrnm) != null);
        }

        private bool AgregarAdmin(Administrativo admin)
        {
            if (admin != null)
            {
                if (this.Administrativos == null) this.Administrativos = new List<Administrativo>();
                if (!this.ExisteAdmin(admin.Usuario))
                {
                    Administrativos.Add(admin);
                    return true; // para avisar si se agregó
                }
            }
            return false; // para avisar si se agregó
        }

        private bool AgregarAdmin(string usu, string pwd, string name) //era bool
        {
            Administrativo nuevoA = new Administrativo(usu, pwd, name);
            return AgregarAdmin(nuevoA); //iba return here
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

        public List<string> obtenerTipoHabitaciones()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            //Provide the current application domain evidence for the assembly.
            Evidence asEvidence = currentDomain.Evidence;
            //Load the assembly from the application directory using a simple name. 

            //Make an array for the list of assemblies.
            Assembly[] assems = currentDomain.GetAssemblies();

            List<string> retorno = new List<string>();
            for (var i = 0; i < assems.Length; i++)
            {
                Assembly a = assems[i];
                string name = a.GetName().Name;
                if (name == "Dominio")
                {
                    Type[] types = a.GetTypes();
                    for (var e = 0; e < types.Length; e++)
                    {
                        Type t = types[e];
                        Type typeHabitacion = Type.GetType("Dominio.EntidadesDominio.Habitacion");
                        if (t.IsSubclassOf(typeHabitacion))
                        {
                            retorno.Add(t.Name);
                        }
                    }
                }
            }
            return retorno;
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
            Pasajero p = new Pasajero(pDocumento, pPaisDoc, pNombre, pDireccion);
            AgregarPasajero(p);
            return p;
        }

        public void AgregarPasajero(Pasajero p) ///////////// NUEVO
        { 
            if (this.Pasajeros == null) this.Pasajeros = new List<Pasajero>();
            this.Pasajeros.Add(p);
        }

        public Pasajero ModificarPasajero(int pDocumento, string pPaisDoc, string pNombre, Direccion pDireccion)
        {
            Pasajero pasajeroAModificar = BuscarPasajeroPorDocPais(pDocumento, pPaisDoc);
            //documento y pais documento deberian ser inmodificables porque permanecen siempre
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

        // para login Pasajero
        public Pasajero existePasajero(string pDoc, string pPais, out string alert){

            Pasajero p = null;
            string issue;
            int intDoc = this.validarPasajero(pDoc, pPais, out issue);
            alert = issue;

            if (intDoc != 0) // si es 0, significa que el doc no era todo numeros o no entraba en el rango de caracteres
            {
                p = BuscarPasajeroPorDocPais(intDoc, pPais);
            }

            return p;
        }

        public int validarPasajero(string pDoc, string pPais, out string issues)
        {
            issues = null;
            int intDoc = 0;
            int.TryParse(pDoc, out intDoc);

            if (intDoc != 0)
            {
                if (!Pasajero.valSizeDocumento(pDoc))
                {
                    intDoc = 0;
                    issues = "El documento debe tener de 8 a 10 caracteres";
                }
            }
            else
            {
                issues = "El documento debe contener solo números";
            }

            return intDoc;
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

        // PORQUE NO CREAR UN METODO MODIFICARDIRECCION() ? -- aunque no hay lista de Direcciones aca

    }
}
