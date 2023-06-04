using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TP3_ASPNET_Equipo17
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Articulo> ListaArticulos { get; set; }
        //public List<Imagenes> Imagenes { get; set; }
        public List<Imagenes> ListaPrimerasImagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    ListaArticulos = negocio.listar();
                    //dgvArticulos.DataSource = negocio.listar();
                    //dgvArticulos.DataBind();

                    ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
                    List<Imagenes> listaImagenesSql = imagenesNegocio.listar();
                    ListaPrimerasImagenes = new List<Imagenes>();
                    foreach (Articulo item in ListaArticulos)
                    {

                        ListaPrimerasImagenes.Add(listaImagenesSql.Find(x => x.IdArticulo == item.Id));

                    }



                    Session.Add("PrimerasImagenes", ListaPrimerasImagenes);

                    /*if (Session["Carrito"] == null)
                    {
                        ClaseCarrito carrito = new ClaseCarrito();
                        Session.Add("Carrito", carrito);
                    }*/

                }
                ListaPrimerasImagenes = (List<Imagenes>)Session["PrimerasImagenes"];


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
           
           

        }
    }
}