<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CarritoPag.aspx.cs" Inherits="TP3_ASPNET_Equipo17.CarritoPag" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <asp:Repeater ID="repCarrito" runat="server">
                <ItemTemplate>
                    <div>
                        <label><%#Eval("Nombre") %></label>
                        <label><%#DataBinder.Eval(Container.DataItem,"Precio","${0:N0}") %></label>
                        <asp:Button runat="server" ID="btnMenos" CssClass="btn btn-primary" Text="-" OnClick="btnMenos_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" />
                        <asp:Label runat="server" ID="lblCantidad"><%#Eval("Cantidad") %></asp:Label>
                        <asp:Button runat="server" ID="btnMas" CssClass="btn btn-primary" Text="+" OnClick="btnMas_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" />
                        <asp:Button runat="server" ID="btnEliminar" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div>
                <asp:Label runat="server" ID="lblPrecioFinal"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%}%>
</asp:Content>
