using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrito
    {
        public List<Articulo> ListaArticulos { get; set; }

        public Carrito()
        {
            ListaArticulos = new List<Articulo>();
        }

        public string precioTotal()
        {
            decimal precioTotal = 0;
            foreach (var item in ListaArticulos)
            {
                precioTotal += item.Cantidad * item.Precio;
            }
            return precioTotal.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }
    }
}
