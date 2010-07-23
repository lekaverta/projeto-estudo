<%@ Page Title="IUSD - Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IUSDSample.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Insert, Update, Select e Delete - Sample</title>
        <link rel="stylesheet" type="text/css" href="/Estilos/Login.css" />
        <style>
            body 
            {
                background:url('http://blopa.werules.com/wp-content/uploads/2009/11/mario_bros_wii_hd.png') no-repeat center;
                font-family:Helvetica;
                font-size:12px;
            }
            table
            {
                border:medium dashed;
                float:right;
                padding:10px;
                width:auto;
            }
            .mensagem-erro
            {
                color:Red;
            }
            .botao
            {
                background:none repeat scroll 0 0 gray;
                border:1px solid;
            }
            td.td-botoes
            {
                text-align:right;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

            <table>
                <tr>
                    <td>Usuário*</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUsername" />
                    </td>
                </tr>
                <tr>
                    <td>Senha*</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword"
                                     TextMode="Password" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="td-botoes">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnLogin" runat="server" 
                                            Text="Logon"
                                            onclick="btnLogin_Click"
                                            CssClass="botao" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="lblMsg" runat="server"
                                           CssClass="mensagem-erro" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>

        </form>
    </body>
</html>
