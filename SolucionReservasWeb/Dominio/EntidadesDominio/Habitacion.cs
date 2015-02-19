using System.Collections.Generic;
using Dominio.Utilidades;
namespace Dominio.EntidadesDominio
{
    public abstract class Habitacion
    {
        #region Atributos
        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private bool tieneJacuzzi;

        public bool TieneJacuzzi
        {
            get { return tieneJacuzzi; }
            set { tieneJacuzzi = value; }
        }

        private bool esExterior;

        public bool EsExterior
        {
            get { return esExterior; }
            set { esExterior = value; }
        }

        private int cantCamasSingles;

        public int CantCamasSingles
        {
            get { return cantCamasSingles; }
            set { cantCamasSingles = value; }
        }

        private int cantCamasDobles;

        public int CantCamasDobles
        {
            get { return cantCamasDobles; }
            set { cantCamasDobles = value; }
        }
        private Precio precio;

        public Precio Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private bool disponible = true;//atributo calculado

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
            return this.numero == h.numero;
        }
        #endregion
        #region Constructores
        public Habitacion(int numero, bool jacuzzi, bool exterior, int camasSimples, int CamasDobles)
        {
            this.numero = numero;
            this.tieneJacuzzi = jacuzzi;
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