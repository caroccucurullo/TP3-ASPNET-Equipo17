<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CarritoPag.aspx.cs" Inherits="TP3_ASPNET_Equipo17.Carrito" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Repeater ID="repCarrito" runat="server">
                <ItemTemplate>
                    <div>
                        <%--<asp:Label runat="server" ID="lblNombre"></asp:Label>
                <asp:Label runat="server" ID="lblPrecio"></asp:Label>--%>
                        <label><%#Eval("Nombre") %></label>
                        <label><%#Eval("Precio") %></label>
                        <asp:Button runat="server" ID="btnMenos" Text="-" OnClick="btnMenos_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" />
                        <asp:Label runat="server" ID="lblCantidad"><%#Eval("Cantidad") %></asp:Label>
                        <%--<label><%#Eval("Cantidad") %></label>--%>
                        <asp:Button runat="server" ID="btnMas" Text="+" OnClick="btnMas_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" />
                        <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo"  />

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
