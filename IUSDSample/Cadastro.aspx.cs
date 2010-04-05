using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Models;

namespace IUSDSample
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                carregarArtistas();
        }

        private void carregarArtistas()
        {
            var filtros = new Dictionary<String, object>();
            filtros.Add("id", 1);

            ddlArtista.DataSource = new ArtistaBL().buscarPorId(new Artista { id = 1 });
            ddlArtista.DataValueField = "id";
            ddlArtista.DataTextField = "titulo";
            ddlArtista.DataBind();
            ddlArtista.Items.Insert(0, new ListItem { Text = "Selecione :)", Value = String.Empty });
        }

        protected void ddlArtista_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarAlbums();
        }

        private void carregarAlbums()
        {
            var filtros = new Dictionary<String, object>();
            filtros.Add("artista_id", Convert.ToInt32(ddlArtista.SelectedValue));

            ddlAlbum.DataSource = new AlbumBL().buscarPorFiltro(filtros);
            ddlAlbum.DataValueField = "id";
            ddlAlbum.DataTextField = "titulo";
            ddlAlbum.DataBind();
        }
    }
}