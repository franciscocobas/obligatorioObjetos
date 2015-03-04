using System;
using System.Collections.Generic;
using Dominio.Utilidades;
using Dominio.EntidadesDominio;
using System.Security.Policy;
using System.Reflection;
using System.Globalization;
using System.Collections;



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
        public List<Direccion> Direcciones { get; private set; }

        #endregion

        # region Carga de datos iniciales
    
        void Inicializar()
        {
            Reservas = new List<Reserva>();
            ConfigurarParametros();
            CargarHabitacionesPrueba();
            CargarServiciosPrueba();
            CargarAdministrativoPrueba();
            CrearPasajero(12345678, "Uruguay", "Pasajero Pasajero", new Direccion("SanMartin3384", "", "Montevideo", "Montevideo", "11710", "Uruguay"));
            CrearPasajero(12345678, "Argentina", "Arg Pasajero", new Direccion("SanMartin84", "", "BsAs", "BsAs", "11710", "Uruguay"));
 
        }

        private void ConfigurarParametros()
        {
            Estandar.PrecioBasicoXCama = new Precio(89);
            CotizacionDolar.Instancia.ActualizarPrecios(23.40M, 20.50M);//M es el sufijo para decimal
        }

        private void CargarServiciosPrueba()
        {
            AgregarServicio(new Servicio("Canoas", new Precio(18M), 75, 89));
            AgregarServicio(new Servicio("Pensión Completa", new Precio(35M), 20, 89));

        }

        private void CargarHabitacionesPrueba()
        {
            AgregarHabitacion(CrearHabitacionEstandar(108, false, true, 2, 1));
            AgregarHabitacion(CrearHabitacionSuite(109, true, true, 0, 1, new Precio(40)));
            AgregarHabitacion(CrearHabitacionSuite(110, true, true, 0, 1, new Precio(25M)));
            AgregarHabitacion(CrearHabitacionSuite(111, false, true, 2, 1, new Precio(25M)));
            AgregarHabitacion(CrearHabitacionSuite(112, false, true, 2, 1, new Precio(25M)));

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

        public Habitacion buscarHabitacionXId(int id)
        {
            Habitacion habitacionEncontrada = null;
            foreach (Habitacion habitacion in this.Habitaciones)
            {
                if (habitacion.Id == id)
                {
                    habitacionEncontrada = habitacion;
                }
            }
            return habitacionEncontrada;
        }

        public List<Habitacion> ObtenerHabitacionesDisponiblesXFecha(DateTime pfechaDesde, DateTime pfechaHasta)
        {
            List<Habitacion> habitacionesNoDisponibles = ObtenerHabitNoDisponiblesXFecha(pfechaDesde, pfechaHasta);

            List<Habitacion> habitacionesDisponibles = new List<Habitacion>();

            foreach(Habitacion habitacion in this.Habitaciones)
            {
                if (!habitacionesNoDisponibles.Contains(habitacion))
                {
                    habitacionesDisponibles.Add(habitacion);
                }
            }

            return habitacionesDisponibles;
        }
        public List<Habitacion> ObtenerHabitacionesNoDisponiblesXTipo(DateTime pFechaDesde, DateTime pFechaHasta, string pTipo)
        {
            List<Habitacion> habitacionesNoDisponibles = ObtenerHabitNoDisponiblesXFecha(pFechaDesde, pFechaHasta);

            List<Habitacion> habitacionesNoDispXTipo = new List<Habitacion>();

            // Filtro por tipo
            foreach (Habitacion habitacion in habitacionesNoDisponibles)
            {
                Type tipoHabitacion = habitacion.GetType();
                if (tipoHabitacion.Name == pTipo)
                {
                    habitacionesNoDispXTipo.Add(habitacion);
                }
            }
            return habitacionesNoDispXTipo;

        }
        public List<Habitacion> ObtenerHabitacionesDisponiblesXTipo(DateTime pFechaDesde, DateTime pFechaHasta, String pTipo, out int cantidadHabitaciones)
        {
            List<Habitacion> habitacionesDispXTipo = new List<Habitacion>();
            List<Habitacion> habitacionesDisponibles = ObtenerHabitacionesDisponiblesXFecha(pFechaDesde, pFechaHasta);
            cantidadHabitaciones = 0;

            // Filtro por tipo
            foreach (Habitacion habitacion in habitacionesDisponibles)
            {
                Type tipoHabitacion = habitacion.GetType();
                if (tipoHabitacion.Name == pTipo)
                {
                    habitacionesDispXTipo.Add(habitacion);
                    cantidadHabitaciones++;
                }
            }
            return habitacionesDispXTipo;
        }
        
        public List<Habitacion> ObtenerHabitNoDisponiblesXFecha(DateTime pFechaDesde, DateTime pFechaHasta)
        {
            List<Habitacion> habitacionesNoDisponibles = new List<Habitacion>();
            foreach (Reserva reserva in this.Reservas)
            {
                if ((pFechaHasta > reserva.FechaDesde && pFechaHasta < reserva.FechaHasta) 
                    || (pFechaDesde > reserva.FechaDesde && pFechaHasta < reserva.FechaHasta)
                    || (pFechaDesde < reserva.FechaHasta && pFechaHasta > reserva.FechaDesde))
                {
                    foreach (Habitacion habitacionOcupadaReserva in reserva.Habitaciones)
                    {
                        if (!habitacionesNoDisponibles.Contains(habitacionOcupadaReserva))
                        {
                            habitacionesNoDisponibles.Add(habitacionOcupadaReserva);
                        }
                    }
                }
            }

            return habitacionesNoDisponibles;
        }

        public List<ArrayList> obtenerHabitacionesIguales(List<Habitacion> habitaciones, out int cantPasajeros)
        {
            List<ArrayList> habitacionesIguales = new List<ArrayList>();
            int contador = 0;
            cantPasajeros = 0;
            ArrayList array = null;
            Habitacion habitacionAComparar = null;
            foreach(Habitacion habitacion in habitaciones)
            { 
                if (habitacionAComparar == null)
                {
                    contador++;
                    array = new ArrayList();
                    array.Add(contador);
                    array.Add(habitacion);
                    habitacionesIguales.Add(array);
                    habitacionAComparar = habitacion;
                }
                else if (habitacionAComparar.SonHabitacionesIguales(habitacion))
                {
                    if (array != null)
                    {
                        contador++;
                        array[0] = contador;
                        habitacionAComparar = habitacion;
                    }
                }else
                {
                    contador = 1;
                    array = new ArrayList();
                    array.Add(contador);
                    array.Add(habitacion);
                    habitacionesIguales.Add(array);
                    habitacionAComparar = habitacion;
                }
                cantPasajeros += (habitacion.CantCamasDobles * 2) + habitacion.CantCamasSingles;
            }
            return habitacionesIguales;
        }
        
        public Habitacion BuscarHabitacionXCama(List<Habitacion> habitacionesNoOcupadas, int cantDobles, int cantSingles, List<Habitacion> HabSelecc)
        {

            Habitacion habitacionEncontrada = null;

            foreach(Habitacion habitacion in habitacionesNoOcupadas)
            {
                if (habitacion.CantCamasDobles == cantDobles && habitacion.CantCamasSingles == cantSingles)
                {
                    if (HabSelecc == null)
                    {
                        habitacionEncontrada = habitacion;
                    }
                    else
                    {
                        if(!HabSelecc.Contains(habitacion))
                        {
                            habitacionEncontrada = habitacion;
                        }
                    }    
                }
            }

            return habitacionEncontrada;
        }

        public List<Habitacion> MostrarHabitNoDisponiblesCPrecio(List<Habitacion> pHabitaciones, Precio pPrecio, DateTime pFechaDesde, DateTime pFechaHasta)
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
            decimal monto = 0M;

            foreach (Habitacion hab in pHabitaciones){
                monto += hab.Precio.MontoDolares;
            }
            
            Precio result = new Precio(monto);

            return result;
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

        public Servicio BuscarServicioXId(int id)
        {
            Servicio servicioEncontrado = null;

            foreach (Servicio s in this.Servicios)
            {
                if (s.Id == id)
                {
                    servicioEncontrado = s;
                }
            }

            return servicioEncontrado;
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

        public Pasajero BuscarPasajeroPorId(int id)
        {
            Pasajero pasajeroEncontrado = null;

            foreach(Pasajero p in this.Pasajeros)
            {
                if (p.Id == id)
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
        public Reserva CrearReserva(int pDoc, string pPais, decimal precioPesos, DateTime pFechaDesde, DateTime pFechaHasta, int pCantMayores, int pCantMenores, List<int> pHabitaciones)
        {
            Reserva reserva = new Reserva();
            reserva.PrecioPesos = precioPesos;
            reserva.FechaDesde = pFechaDesde;
            reserva.FechaHasta = pFechaHasta;
            reserva.CantMayores = pCantMayores;
            reserva.CantMenores = pCantMenores;
            reserva.Activa = true;
            
            foreach (int id in pHabitaciones)
            {
                Habitacion habitacionEncontrada = this.buscarHabitacionXId(id);
                if (habitacionEncontrada != null)
                {
                    reserva.AgregarHabitacion(habitacionEncontrada);
                }
            }

            if (this.Reservas == null) this.Reservas = new List<Reserva>();
            this.Reservas.Add(reserva);

            Pasajero p = BuscarPasajeroPorDocPais(pDoc, pPais);
            p.AgregarReservaPas(reserva);

            return reserva;
        }

        public Reserva buscarReservaXId(int id)
        {
            Reserva reservaEncontrada = null;

            foreach (Reserva reserva in this.Reservas)
            {
                if (reserva.Id == id)
                {
                    reservaEncontrada = reserva;
                }
            }

            return reservaEncontrada;
        }

        public void CancelarReserva(int pDocPasajero, string pPais, int pIdReserva)
        {
            Pasajero pas = BuscarPasajeroPorDocPais(pDocPasajero, pPais);
            Reserva res = buscarReservaXId(pIdReserva);

            pas.EliminarReserva(res);
        }

        public List<Reserva> RecuperarReservasActivas(Pasajero pPasajero)
        {
            List<Reserva> reservasProximasActivas = new List<Reserva>();

            Reserva reservaProxima = null;

            if (pPasajero.listaReservas != null)
            {
                foreach (Reserva r in pPasajero.listaReservas)
                {
                    if (r.Activa == true && !r.Expirada)
                    {
                        if (reservaProxima == null)

                            reservaProxima = r;

                        if (r.FechaDesde < reservaProxima.FechaDesde)
                        {
                            reservaProxima = r;

                            if (reservasProximasActivas.Count == 0)
                            {
                                reservasProximasActivas.Add(reservaProxima);
                            }
                            else
                            {
                                reservasProximasActivas = new List<Reserva>();
                                reservasProximasActivas.Add(reservaProxima);
                            }
                        }
                        else if (r.FechaDesde == reservaProxima.FechaDesde)
                        {
                            reservaProxima = r;
                            reservasProximasActivas.Add(reservaProxima);
                        }
                    }
                }
            }

            reservasProximasActivas.Sort();

            return reservasProximasActivas;
        }

        #endregion

        #region Direccion

        public Direccion ModificarDireccion(int pdoc, string pPaisDoc, string pDireccion1, string pDireccion2, string pCiudad, string pDptoProv, string pCP, string pPais) 
        {   
            //ya corrobore que existe la direccion porque sino no habria llegado a donde estoy
            Direccion dir = this.BuscarDireccion(pdoc, pPaisDoc, pDireccion1, pDireccion2, pCiudad, pDptoProv, pCP, pPais);

            dir.CalleNro = pDireccion1;
            dir.DirAdicional = pDireccion2;
            dir.Ciudad = pCiudad;
            dir.DptoProvincia = pDptoProv;
            dir.CodigoPostal = pCP;
            dir.Pais = pPais;
            
            return dir;
        }


        public Direccion BuscarDireccion(int pdoc, string pPaisDoc, string pDireccion1, string pDireccion2, string pCiudad, string pDptoProv, string pCP, string pPais) 
        {
	        Direccion d;
            Pasajero pas = this.BuscarPasajeroPorDocPais(pdoc, pPaisDoc);
            d = pas.Direccion;

	        return d;
        }


        #endregion
        
        #region Otros

        public List<string> listaPaises()
        {
            ListaPaises.llenarPaises();
            return ListaPaises.Nombres;
        }

        public bool ValidarPrecios(string pVenta, string pCompra, out decimal newVenta, out decimal newCompra)
        {     
            bool valid = false;
            newCompra = 0M;
            bool exito = decimal.TryParse(pCompra, NumberStyles.Any, CultureInfo.InstalledUICulture, out newCompra);
            newVenta = 0M;
            bool exito2 = decimal.TryParse(pVenta, NumberStyles.Any, CultureInfo.InstalledUICulture, out newVenta);
            
            if (exito && exito2) valid = true;

            return valid;
        }

        public Precio MostrarDineroRecaudado()
        {
            decimal decTotal = 0M;
            foreach (Reserva res in Reservas)  //salta error aca, pero puede ser porque no tengo reservas todavia
            {
                decTotal += res.CalcularPrecio().MontoDolares;
            }

            Precio precioTot = new Precio(decTotal);

            return precioTot;
        }

        public void chequearReservasExpiradas() 
        {
            foreach (Reserva reserva in this.Reservas)
            {
                if (reserva.FechaDesde < DateTime.Today)
                {
                    reserva.Expirada = true;
                }
            }
        }

        #endregion

    }
}
