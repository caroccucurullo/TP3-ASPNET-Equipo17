<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CarritoPag.aspx.cs" Inherits="TP3_ASPNET_Equipo17.CarritoPag" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .columna {
            
            display: flex;
            flex-direction: column !important;
            justify-content: center;
            align-content: center;
        }
        .columna img {
            align-self:center;
        }
        .box {
            width: 100px;
            height: 100px;
            border: 1px solid #000;
            margin: 10px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (CarritoVacio)
        {
    %>
    <h2>No hay articulos en el carrito :(</h2>
    <h3>Ve a explorar el catalogo</h3>
    <a href="Default.aspx" class="btn btn-primary">Home</a>
    <%}
        else
        { %>
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="d-flex">
                <div class="columna">
                    <asp:Repeater runat="server" ID="repImagenes">
                        <ItemTemplate>
                            <asp:Image runat="server" CssClass="box" Height="50px" Width="50px" ImageUrl='<%#Eval("ImagenUrl") %>' onerror="this.src='https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png';" />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="flex-column">
                    <asp:Repeater ID="repCarrito" runat="server">
                        <ItemTemplate>
                            <div class="container text-center m-2">
                                <div class="row row-cols-auto row-gap-3 fw-semibold flex-nowrap">
                                    <div class="p-3 col-5">
                                        <label><%#Eval("Nombre") %></label>
                                    </div>
                                    <div class="p-3 col-3">
                                        <label><%#DataBinder.Eval(Container.DataItem,"Precio","${0:N0}") %></label>
                                    </div>
                                    <div class="p-2 col">
                                        <asp:Button runat="server" ID="btnMenos" CssClass="btn btn-primary" Text="-" OnClick="btnMenos_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" />
                                    </div>
                                    <div class="p-3 col">
                                        <asp:Label runat="server" ID="lblCantidad"><%#Eval("Cantidad") %></asp:Label>
                                    </div>
                                    <div class="p-2 col">
                                        <asp:Button runat="server" ID="btnMas" CssClass="btn btn-primary" Text="+" OnClick="btnMas_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" />
                                    </div>
                                    <div class="p-2 col">
                                        <asp:Button runat="server" ID="btnEliminar" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="bg-black container text-center m-2 fw-medium fs-5 text-white mx-auto">
                <div class="row row-cols-auto row-gap-3">
                    <div class="p-2 col-5">
                        <p>Total</p>
                    </div>
                    <div class="p-2 col-3">
                        <asp:Label runat="server" ID="lblPrecioFinal"></asp:Label>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%}%>
</asp:Content>
