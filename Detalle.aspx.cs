using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Runtime.InteropServices;

namespace TP3_ASPNET_Equipo17
{
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Imagenes> ListaImagenes { get; set; }
        public Articulo Articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int idQuery = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : -1;
                    if (idQuery > 0)
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo = negocio.buscarPorId(idQuery);
                        Session.Add("DetalleArticulo", Articulo);
                        ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
                        ListaImagenes = imagenesNegocio.ListaPorId(idQuery);
                        RepImagesList.DataSource = ListaImagenes;
                        RepImagesList.DataBind();
                        mainImageBox.ImageUrl = ListaImagenes[0].ImagenUrl;
                        lblCodigo.Text = Articulo.Codigo;
                        lblDescripcion.Text = Articulo.Descripcion;
                        lblMarca.Text = Articulo.Marca.Descripcion;
                        lblCategoria.Text = Articulo.Categoria.Descripcion;
                        lblPrecio.Text = Articulo.Precio.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                    }
                    else
                    {
                        mainImageBox.Visible = false;
                    }
                }
                else
                {
                    Articulo = (Articulo)Session["DetalleArticulo"];
                    ListaImagenes = (List<Imagenes>)Session["PrimerasImagenes"];
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }        
        }

        protected void boxImagesList_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                mainImageBox.ImageUrl = ((ImageButton)sender).CommandArgument;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            if (!((Carrito)Session["Carrito"]).ListaArticulos.Exists(x => x.Id == Articulo.Id))
            {
                Articulo.Cantidad = 1;
                ((Carrito)Session["Carrito"]).ListaArticulos.Add(Articulo);
                ((Carrito)Session["Carrito"]).ListaImagenes.Add(ListaImagenes.Find(x => x.IdArticulo == Articulo.Id));
                lblCarrito.Text = "Articulo " + Articulo.Id.ToString() + " Agregado";
            }
            else
            {
                lblCarrito.Text = "Ya existe";
            }
        }
    }
}