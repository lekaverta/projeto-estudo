<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SiteDefault.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="IUSDSample.Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphConteudo" runat="server">

    <asp:GridView ID="gdvRegistros" CssClass="registros" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="id" />
            <asp:BoundField HeaderText="Título" DataField="titulo" />
            <asp:TemplateField HeaderText="Artista/Banda">
                <ItemTemplate>
                    <a href='Listar.aspx?artista=<%#DataBinder.Eval(Container.DataItem, "artista.id")%>'>
                        <%--<%#DataBinder.Eval(Container.DataItem, "artista.id")%>--%>
                        <%--<%#DataBinder.Eval(Container.DataItem, "artista.titulo")%>--%>
                        <%#DataBinder.Eval(Container.DataItem, "album.artista.titulo")%>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Albúm">
                <ItemTemplate>
                    <a href='Listar.aspx?album=<%#DataBinder.Eval(Container.DataItem, "album.id")%>'>
                        <%--<%#DataBinder.Eval(Container.DataItem, "album.id")%>--%>
                        <%#DataBinder.Eval(Container.DataItem, "album.titulo")%>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
