using System;
using System.Collections;
namespace Dominio.EntidadesDominio
{
    public class Suite : Habitacion
    {
        #region Atributos
        private Precio precioFijoDls;

        public Precio PrecioFijoDls
        {
            get { return precioFijoDls; }
            set { precioFijoDls = value; }
        }
        #endregion
        #region Constructores
        public Suite(int numero, bool jacuzzi, bool exterior, int camasSimples, int camasDobles, Precio precioBase)
            : base(numero, jacuzzi, exterior, camasSimples, camasDobles)
        {
            this.PrecioFijoDls = precioBase;
            this.Precio = this.CalcularPrecioTotal();
        }
        #endregion
        #region Comportamiento específico



        internal override Precio CalcularPrecioTotal()
        {
            return new Precio(this.precioFijoDls.MontoDolares
                * (CantCamasSingles + CantCamasDobles * 2) * 10 / 100
                + this.PrecioFijoDls.MontoDolares);
        }
        #endregion
    }

}