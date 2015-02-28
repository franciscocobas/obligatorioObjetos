using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Precio

    {
        public decimal MontoDolares { get; set; }
        private const string dolares = "U$S ";
        private const string dolaresTexto = "Dólares americanos";
        private const string pesos = "$ ";
        private const string pesosTexto = "Pesos Uruguayos ";

        public Precio(decimal monto)
        {
            this.MontoDolares = monto;
        }
        public override string ToString()
        {
            return dolares + this.MontoDolares + " --> " + pesos + ConvertirAPesos(CotizacionDolar.Instancia.PrecioCompra);
        }
        public decimal ConvertirAPesos(decimal cotizacion)
        {
            return Math.Round (this.MontoDolares * cotizacion,2);
        }

        public override bool Equals(Object obj)
        {
            Precio precio = obj as Precio;
            if (obj == null) return false;
            return this.MontoDolares == precio.MontoDolares;
        }
    }
}
