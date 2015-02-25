using System.Collections.Generic;
using Dominio.Utilidades;
namespace Dominio.EntidadesDominio
{
    public abstract class Habitacion
    {
        #region Atributos
        private int id;
        static int ultId;
        private int numeroHabitacion;
        private bool jacuzzi;
        private bool esExterior;
        private int cantCamasSingles;
        private int cantCamasDobles;
        private Precio precio;
        private bool disponible = true;//atributo calculado


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public static int UltId
        {
            get { return Habitacion.ultId; }
            set { Habitacion.ultId = value; }
        }

        public int Numero
        {
            get { return numeroHabitacion; }
            set { numeroHabitacion = value; }
        }


        public bool TieneJacuzzi
        {
            get { return jacuzzi; }
            set { jacuzzi = value; }
        }


        public bool EsExterior
        {
            get { return esExterior; }
            set { esExterior = value; }
        }


        public int CantCamasSingles
        {
            get { return cantCamasSingles; }
            set { cantCamasSingles = value; }
        }

        public int CantCamasDobles
        {
            get { return cantCamasDobles; }
            set { cantCamasDobles = value; }
        }

        public Precio Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }
       

        #endregion
        #region Redefiniciones de object
       
        public override bool Equals(object obj)
        {
            Habitacion h = obj as Habitacion;
            if (obj == null) return false;
            return this.numeroHabitacion == h.numeroHabitacion;
        }

        public override int GetHashCode() /// agregué esto porque me decia: Warning1 'Dominio.EntidadesDominio.Habitacion' overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
        #region Constructores
        public Habitacion(int numero, bool jacuzzi, bool exterior, int camasSimples, int CamasDobles)
        {
            this.numeroHabitacion = numero;
            this.jacuzzi = jacuzzi;
            this.esExterior = exterior;
            this.cantCamasSingles = camasSimples;
            this.CantCamasDobles = CamasDobles;
        }
        #endregion
        #region Comportamiento 
        internal abstract Precio CalcularPrecioTotal();

        #endregion

    }

}