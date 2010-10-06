using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace IUSDSample
{
    public partial class SiteDefault : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                carregarMenuItens();
        }

        private void carregarMenuItens()
        {
            var simulacaoRegistros = new Dictionary<int, string>();
            simulacaoRegistros.Add(1, "/imagens/Flor-de-lotus.jpg");
            simulacaoRegistros.Add(5, "/imagens/Flor-de-lotus.jpg");
            simulacaoRegistros.Add(6, "/imagens/Flor-de-lotus.jpg");
            simulacaoRegistros.Add(9, "/imagens/Flor-de-lotus.jpg");
            simulacaoRegistros.Add(15, "/imagens/Flor-de-lotus.jpg");

            rptMenuImagens.DataSource = simulacaoRegistros;
            rptMenuImagens.DataBind();
        }

        protected void btnItemMenu_Click(object sender, ImageClickEventArgs e)
        {
            var btnItemMenu = (ImageButton)sender;
            var idSelecionado = btnItemMenu.CommandArgument;
            Session["menuSelecionado"] = idSelecionado;
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "MENU",
                                                    String.Format("javascript:alert('Id do menu selecionado: {0}');",
                                                                  idSelecionado), true);
        }

        protected void rptMenuImagens_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var btnItemMenu = (ImageButton) e.Item.FindControl("btnItemMenu");
                btnItemMenu.ImageUrl = DataBinder.Eval(e.Item.DataItem, "value").ToString();
                btnItemMenu.CommandArgument = DataBinder.Eval(e.Item.DataItem, "key").ToString();
            }
        }
    }
}