using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace IUSDSample
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("logout") != null)
                logout();
        }

        private void logout()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Login.aspx", true);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarUsuario())
                    FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, true);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        private bool validarUsuario()
        {
            if (txtUsername.Text != "admin")
                throw new Exception("Usuário inválido.");
            else if (txtPassword.Text != "admin")
                throw new Exception("Senha inválida.");
            else
                return true;
        }
    }
}