<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SiteDefault.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IUSDSample.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphConteudo" runat="server">
    <br />
    <br />
    Default Page
    <input type="submit" Value="SignOut" runat="server" id="cmdSignOut">
<%--    <table>
       <tr>
          <td>Usuário:</td>
          <td><input id="txtUserName" type="text" runat="server"></td>
          <td><ASP:RequiredFieldValidator ControlToValidate="txtUserName"
               Display="Static" ErrorMessage="*" runat="server" 
               ID="vUserName" /></td>
       </tr>
       <tr>
          <td>Senha:</td>
          <td><input id="txtUserPass" type="password" runat="server"></td>
          <td><ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
              Display="Static" ErrorMessage="*" runat="server" 
              ID="vUserPass" />
          </td>
       </tr>
       <tr>
          <td>Permanecer Logado?</td>
          <td><ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false" /></td>
          <td></td>
       </tr>
    </table>
    <asp:Button ID="cmdLogin" runat="server" Text="Logon" Font-Names="Verdana" 
        onclick="cmdLogin_Click" /><p></p>
    <asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />--%>

</asp:Content>
