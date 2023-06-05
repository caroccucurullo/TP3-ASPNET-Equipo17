using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_ASPNET_Equipo17
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

			try
			{
                if (!IsPostBack)
                {
                    repCarrito.DataSource = ((Carrito)Session["Carrito"]).ListaArticulos;
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
            foreach (var item in ((Carrito)Session["Carrito"]).ListaArticulos)
            {
                if (item.Id == id)
                {
                    if (item.Cantidad == 0)
                    {
                        item.Cantidad = 0;
                        return;
                    }
                    item.Cantidad--;
                    repCarrito.DataSource = ((Carrito)Session["Carrito"]).ListaArticulos;
                    repCarrito.DataBind();
                }
                    
            }
            
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            foreach (var item in ((Carrito)Session["Carrito"]).ListaArticulos)
            {
                if (item.Id == id)
                {
                    item.Cantidad++;
                    repCarrito.DataSource = ((Carrito)Session["Carrito"]).ListaArticulos;
                    repCarrito.DataBind();
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            //foreach (var item in ((Carrito)Session["Carrito"]).ListaArticulo)
            for(int x=0;x < ((Carrito)Session["Carrito"]).ListaArticulos.Count;x++)
            {
                if (((Carrito)Session["Carrito"]).ListaArticulos[x].Id == id)
                {
                    ((Carrito)Session["Carrito"]).ListaArticulos.Remove(((Carrito)Session["Carrito"]).ListaArticulo[x]);
                    repCarrito.DataSource = ((Carrito)Session["Carrito"]).ListaArticulos;
                    repCarrito.DataBind();
                }
            }
        }
    }
}