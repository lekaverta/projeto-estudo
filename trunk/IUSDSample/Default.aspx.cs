using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

namespace IUSDSample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cmdSignOut.ServerClick += new System.EventHandler(this.cmdSignOut_ServerClick);
            
            //if (!this.IsPostBack)
            //    this.Form.DefaultFocus = txtUsuario.ClientID;

        }

        private void cmdSignOut_ServerClick(object sender, System.EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx", true);
        }

    }
}