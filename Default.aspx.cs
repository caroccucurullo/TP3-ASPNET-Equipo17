using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TP3_ASPNET_Equipo17
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Articulo> ListaArticulos { get; set; }
        public List<Imagenes> ListaPrimerasImagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    ListaArticulos = negocio.listar();
                    ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
                    List<Imagenes> listaImagenesSql = imagenesNegocio.listar();
                    ListaPrimerasImagenes = new List<Imagenes>();
                    foreach (Articulo item in ListaArticulos)
                    {
                        ListaPrimerasImagenes.Add(listaImagenesSql.Find(x => x.IdArticulo == item.Id));
                    }
                    Session.Add("ListaArticulos", ListaArticulos);
                    Session.Add("PrimerasImagenes", ListaPrimerasImagenes);

                    if (Session["Carrito"] == null)
                    {
                        Carrito carrito = new Carrito();
                        Session.Add("Carrito", carrito);
                    }
                }
                ListaPrimerasImagenes = (List<Imagenes>)Session["PrimerasImagenes"];
                ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Imagenes> listaImagenes = (List<Imagenes>)Session["PrimerasImagenes"];
            List<Articulo> listaFiltrada = ((List<Articulo>)Session["ListaArticulos"]).FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            List<Imagenes> listaImagenesFiltrada = new List<Imagenes>();
            foreach (Articulo item in listaFiltrada)
            {
                foreach (var img in listaImagenes)
                {
                    if (img != null)
                    {
                        if (img.IdArticulo == item.Id)
                        {
                            listaImagenesFiltrada.Add(img);
                            break;
                        }
                    }
                    else
                    {
                        Imagenes vacio = new Imagenes()
                        {
                            IdArticulo = item.Id,
                            ImagenUrl = ""
                        };
                        listaImagenesFiltrada.Add(vacio);
                    }
                }
            }
            ListaArticulos = listaFiltrada;
            ListaPrimerasImagenes = listaImagenesFiltrada;
        }

    }
}