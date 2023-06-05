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

        public void Agregar(Articulo art)
        {
            ListaArticulos.Add(art);
        }

        public void Eliminar(Articulo art)
        {
            ListaArticulos.Remove(art);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in ListaArticulos)
            {
                total += item.Precio;
            }
            return total;
        }

        public void Vaciar()
        {
            ListaArticulos.Clear();
        }


    }
}
