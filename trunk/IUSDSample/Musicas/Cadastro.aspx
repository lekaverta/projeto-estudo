<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SiteDefault.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="IUSDSample.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphConteudo" runat="server">

    <h2><%= Request.QueryString.Get("codigo") != null ? "Editar" : "Nova" %> Música</h2>
    
    <table class="formulario">
        <tbody>
            <tr>
                <td class="titulo">Título</td>
                <td>
                    <asp:HiddenField runat="server" ID="hdnCodigo" Value="0" />
                    <asp:TextBox ID="txtTitulo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="titulo">Artista</td>
                <td><asp:DropDownList ID="ddlArtista" 
                        runat="server" AutoPostBack="true" 
                        onselectedindexchanged="ddlArtista_SelectedIndexChanged" /></td>
            </tr>
            <tr>
                <td class="titulo">Albúm</td>
                <td><asp:DropDownList ID="ddlAlbum" runat="server" /></td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2" class="submits">
                    <asp:Label ID="lblMensagem" runat="server" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="submits">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                        onclick="btnSalvar_Click" />
                </td>
            </tr>
        </tfoot>
    </table>

</asp:Content>
