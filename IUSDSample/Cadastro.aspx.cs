using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Models;
using System.Drawing;

namespace IUSDSample
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                carregarArtistas();

            lblMensagem.Text = String.Empty;
        }

        private void carregarArtistas()
        {
            ddlArtista.DataSource = new ArtistaBL().listarTodos();
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                new MusicaBL().salvar(retornarMusicaDoForm());
                sucessoGenerico();
            }
            catch (Exception ex)
            {
                erroGenerico(ex);
            }
        }

        private void erroGenerico(Exception ex)
        {
            lblMensagem.ForeColor = Color.Red;
            lblMensagem.Text = String.Concat("Erro - ", ex.Message);
        }

        private void sucessoGenerico()
        {
            lblMensagem.Text = "Ok! ;)";
            lblMensagem.ForeColor = Color.Green;
        }

        private Musica retornarMusicaDoForm()
        {
            return new Musica()
            {
                titulo = txtTitulo.Text,
                artista = new Artista() { id = int.Parse(ddlArtista.SelectedValue), titulo = ddlArtista.SelectedItem.Text },
                album = new Album() { id = int.Parse(ddlAlbum.SelectedValue), titulo = ddlAlbum.SelectedItem.Text }
            };
        }
    }
}