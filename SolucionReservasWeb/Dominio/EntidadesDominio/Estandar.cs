namespace Dominio.EntidadesDominio
{
    public class Estandar : Habitacion
    {       
        private static Precio precioBasicoXCama;

        public static Precio PrecioBasicoXCama
        {
            get { return Estandar.precioBasicoXCama; }
            set { Estandar.precioBasicoXCama = value; }
        }

        public Estandar(int numero, bool jacuzzi, bool exterior, int camasSimples, int camasDobles)
            : base(numero, jacuzzi, exterior, camasSimples, camasDobles)
        {
            this.Precio = this.CalcularPrecioTotal();
        }

        internal override Precio CalcularPrecioTotal()
        {
            return new Precio(Estandar.PrecioBasicoXCama.MontoDolares * (CantCamasSingles + CantCamasDobles * 2));
        }
    }
}
