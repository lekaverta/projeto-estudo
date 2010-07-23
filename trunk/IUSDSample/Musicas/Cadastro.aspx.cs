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
            {
                carregarArtistas();
                editarMusica();
            }

            lblMensagem.Text = String.Empty;
        }

        private void editarMusica()
        {
            if (Request.QueryString.Get("codigo") != null)
            {
                var musica = new Musica(new Album(new Artista()));
                musica.id = Convert.ToInt32(Request.QueryString.Get("codigo"));
                musica = MusicaBL.buscarPorId(musica);

                carregarMusicaEmForm(musica);
            }
        }

        private void carregarMusicaEmForm(Musica musica)
        {
            ddlArtista.SelectedValue = musica.artista.id.ToString();
            ddlAlbum.SelectedValue = musica.artista.id.ToString();
            txtTitulo.Text = musica.titulo;
            hdnCodigo.Value = musica.id.ToString();
        }

        private void carregarArtistas()
        {
            ddlArtista.DataSource = ArtistaBL.listarTodos();
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

            ddlAlbum.DataSource = AlbumBL.buscarPorFiltro(filtros);
            ddlAlbum.DataValueField = "id";
            ddlAlbum.DataTextField = "titulo";
            ddlAlbum.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var musica = retornarMusicaDoForm();
                MusicaBL.salvar(musica);

                hdnCodigo.Value = musica.id.ToString();
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
            var artista = new Artista() { 
                id = int.Parse(ddlArtista.SelectedValue), 
                titulo = ddlArtista.SelectedItem.Text 
            };

            var album = new Album(artista);
            album.id  = int.Parse(ddlAlbum.SelectedValue);
            album.titulo = ddlAlbum.SelectedItem.Text;

            var musica = new Musica(album);
            musica.titulo = txtTitulo.Text;
            musica.artista = artista;
            musica.id = Convert.ToInt32(hdnCodigo.Value);

            return musica;
        }
    }
}