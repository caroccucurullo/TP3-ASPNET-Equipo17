<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TP3_ASPNET_Equipo17.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .box {
            width: 100px;
            height: 100px;
            border: 1px solid #000;
            margin: 10px 0;
        }

        .mainBox {
            width: 650px;
            height: 700px;
            object-fit: cover;
        }

        .oculto {
            display: none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" CssClass="d-flex">
        <ContentTemplate>
            <div class="row d-flex mb-5 mt-5">
                <div class="col-2 d-flex flex-column">
                    <asp:Repeater ID="RepImagesList" runat="server">
                        <ItemTemplate>
                            <asp:ImageButton ID="boxImagesList" runat="server" CssClass="box" OnClick="boxImagesList_Click" ImageUrl='<%#Eval("ImagenUrl")%>'
                                CommandArgument='<%#Eval("ImagenUrl") %>' CommandName="ImagenUrlActual" onerror="this.src='https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png';" />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col">
                    <asp:Image ID="mainImageBox" runat="server" CssClass="box mainBox" onerror="this.src='https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png';" />
                </div>
                <div class="col-2">
                    <%if (Articulo != null)
                        {
                    %>
                    <h2><%:Articulo.Nombre%></h2>
                    <%
                        }
                    %>
                    <div class="<%: Articulo != null ? "d-flex" : "oculto"%>">
                        <div class="d-flex flex-column">
                            <label>Codigo</label>
                            <label>Descripcion</label>
                            <label>Marca</label>
                            <label>Categoria</label>
                            <label>Precio</label>
                        </div>
                        <div class="d-flex flex-column">
                            <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                            <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                            <asp:Label ID="lblMarca" runat="server"></asp:Label>
                            <asp:Label ID="lblCategoria" runat="server"></asp:Label>
                            <asp:Label ID="lblPrecio" runat="server"></asp:Label>
                        </div>
                    </div>
                    <asp:Button ID="btnCarrito" runat="server" Text="Añadir al carrito" CssClass="btn btn-primary" OnClick="btnCarrito_Click"/>
                    <asp:Label ID="lblCarrito" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
