using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_ASPNET_Equipo17
{
    public partial class CarritoPag : System.Web.UI.Page
    {
        public string PrecioTotal { get; set; }
        public Carrito PropCarrito { get; set; }
        public bool CarritoVacio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                PropCarrito = (Carrito)Session["Carrito"];
                if (!IsPostBack)
                {

                    if (PropCarrito.ListaArticulos.Count > 0)
                    {
                        CarritoVacio = false;
                        lblPrecioFinal.Text = PropCarrito.precioTotal();
                        
                    }
                    else
                    {
                        CarritoVacio = true;
                        lblPrecioFinal.Visible = false;
                    }
                    repImagenes.DataSource = PropCarrito.ListaImagenes;
                    repImagenes.DataBind();
                    repCarrito.DataSource = PropCarrito.ListaArticulos;
                    repCarrito.DataBind();
                }
            }
			catch (Exception ex)
			{
				Session.Add("Error", ex);
				throw;
			}
        }

        protected void btnMenos_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            foreach (var item in PropCarrito.ListaArticulos)
            {
                if (item.Id == id)
                {
                    if (item.Cantidad >= 2)
                    {
                        item.Cantidad--;
                        repCarrito.DataSource = PropCarrito.ListaArticulos;
                        repCarrito.DataBind();
                        lblPrecioFinal.Text = PropCarrito.precioTotal();
                    }
                }     
            }
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            foreach (var item in PropCarrito.ListaArticulos)
            {
                if (item.Id == id)
                {
                    item.Cantidad++;
                    repCarrito.DataSource = PropCarrito.ListaArticulos;
                    repCarrito.DataBind();
                    lblPrecioFinal.Text = PropCarrito.precioTotal();
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            for(int x=0;x < PropCarrito.ListaArticulos.Count;x++)
            {
                if (PropCarrito.ListaArticulos[x].Id == id)
                {
                    PropCarrito.ListaArticulos.Remove(PropCarrito.ListaArticulos[x]);
                    PropCarrito.ListaImagenes.Remove(PropCarrito.ListaImagenes[x]);
                    repImagenes.DataSource = PropCarrito.ListaImagenes;
                    repImagenes.DataBind();
                    repCarrito.DataSource = PropCarrito.ListaArticulos;
                    repCarrito.DataBind();
                    lblPrecioFinal.Text = PropCarrito.precioTotal();
                }
            }
            if (PropCarrito.ListaArticulos.Count == 0)
            {
                CarritoVacio = true;
                lblPrecioFinal.Visible = false;
                Response.Redirect("CarritoPag.aspx");
            }
        }
    }
}