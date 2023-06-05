<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP3_ASPNET_Equipo17.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        a {
            text-decoration: none !important;
        }
        a:hover {
            transform: scale(1.1);
            transition: all 1s ease;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Artículos</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label runat="server" Text="Filtrar"></asp:Label>
                <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4" runat="server">
        <%if (ListaArticulos != null)
          {
        %>
             <%for (int i = 0; i < ListaArticulos.Count; i++)
               {
             %>
                <a href="Detalle.aspx?id=<%:ListaArticulos[i].Id.ToString() %>">
                    <div class="card" style="width: 18rem; margin: 10px 15px">
                        <img style="height: 18rem;" src="<%: ListaPrimerasImagenes[i] != null ? ListaPrimerasImagenes[i].ImagenUrl : "" %>" class="card-img-top" onerror="this.src='https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png';" alt="">
                        <div class="card-body">
                            <h5 class="card-title"><%:ListaArticulos[i].Nombre %></h5>
                            <p class="card-text"><%:ListaArticulos[i].Descripcion %></p>
                            <p class="card-text"><%:ListaArticulos[i].Precio.ToString("C2",System.Globalization.CultureInfo.GetCultureInfo("en-US")) %></p>
                        </div>
                    </div>
                </a>
             <%}%>
        <%}
          else 
          {%>
            <h2>No se encontraron Articulos en el catalogo.</h2>
        <%} %>
    </div>
</asp:Content>
