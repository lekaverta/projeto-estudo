using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using IUSDSample.Util;

namespace IUSDSample
{
    public partial class Login : System.Web.UI.Page
    {
        // Merlin - Usei como exemplo para criar o login o seguinte tuto: http://support.microsoft.com/kb/301240

        #region Parametros
        private bool ErroLogin
        {
            get
            {
                return (AspHelper.ParamPaginaInt("Erro") > 0 ? true : false);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.ErroLogin)
                    this.lblMsg.Text = "Login ou Senha Inválidos!";
            }
        }

        public bool ValidarUsuario(string Usuario, string Senha)
        {
            if (Usuario == "admin" && Senha == "admin")
                return true;
            else
                return false;
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            if (ValidarUsuario(txtUserName.Value, txtUserPass.Value))
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Value,chkPersistCookie.Checked);
            else
                Response.Redirect("login.aspx?Erro=1", true);
        }
    }
}