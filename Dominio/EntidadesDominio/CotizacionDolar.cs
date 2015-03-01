using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesDominio
{
    public class CotizacionDolar
    {
        #region Singleton
        private readonly static CotizacionDolar instancia = new CotizacionDolar();
        private CotizacionDolar()
        {
            this.PrecioCompra = 23;
            this.PrecioVenta = 25;
        }
        public static CotizacionDolar Instancia
        {
            get { return instancia; }
        }
        #endregion

        public Decimal PrecioVenta { get; private set; }
        public Decimal PrecioCompra { get; private set; }
        public void ActualizarPrecios(decimal precioVta, decimal precioCompra)
        {
            this.PrecioVenta = precioVta;
            this.PrecioCompra = precioCompra;

        }
    }
}
