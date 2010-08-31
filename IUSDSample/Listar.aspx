<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SiteDefault.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="IUSDSample.Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphConteudo" runat="server">

    <asp:UpdatePanel runat="server" ID="upRegistros">
        <ContentTemplate>
            <asp:GridView ID="gdvRegistros" CssClass="registros" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="id" />
                    <asp:BoundField HeaderText="Título" DataField="titulo" />
                    <asp:TemplateField HeaderText="Artista/Banda">
                        <ItemTemplate>
                            <a href='Listar.aspx?artista=<%#DataBinder.Eval(Container.DataItem, "album.artista.id")%>'>
                                <%#DataBinder.Eval(Container.DataItem, "album.artista.titulo")%>
                            </a>
                            <a class="lk-editar" href='Artistas/Cadastro.aspx?codigo=<%#DataBinder.Eval(Container.DataItem, "album.artista.id")%>'>
                                editar
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Albúm">
                        <ItemTemplate>
                            <a href='Listar.aspx?album=<%#DataBinder.Eval(Container.DataItem, "album.id")%>'>
                                <%#DataBinder.Eval(Container.DataItem, "album.titulo")%>
                            </a>
                            <a class="lk-editar" href='Albuns/Cadastro.aspx?codigo=<%#DataBinder.Eval(Container.DataItem, "album.id")%>'>
                                editar
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lkbExcluir" 
                                            CommandArgument='<%#DataBinder.Eval(Container.DataItem, "id")%>'
                                            Text="excluir" 
                                            OnClientClick="javascript:return confirm('Confirma exclusão da música?');"
                                            onclick="lkbExcluir_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
