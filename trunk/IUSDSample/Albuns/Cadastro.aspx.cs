using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Drawing;
using Business;

namespace IUSDSample.Albuns
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregarArtistas();
                editarAlbum();
            }
        }

        private void carregarArtistas()
        {
            ddlArtista.DataSource = ArtistaBL.listarTodos();
            ddlArtista.DataValueField = "id";
            ddlArtista.DataTextField = "titulo";
            ddlArtista.DataBind();
            ddlArtista.Items.Insert(0, new ListItem { Text = "Selecione :)", Value = String.Empty });
        }

        private void editarAlbum()
        {
            if (Request.QueryString.Get("codigo") != null)
            {
                var album = new Album(new Artista());
                album.id = Convert.ToInt32(Request.QueryString.Get("codigo"));
                album = AlbumBL.buscarPorId(album);

                carregarAlbumEmForm(album);
            }
        }

        private void carregarAlbumEmForm(Album album)
        {
            hdnCodigo.Value = album.id.ToString();
            txtTitulo.Text = album.titulo;
            txtAnoLancamento.Text = album.ano_lancamento.ToString();
            ddlArtista.SelectedValue = album.artista.id.ToString();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var album = retornarAlbumDoForm();
                AlbumBL.salvar(album);

                hdnCodigo.Value = album.id.ToString();
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

        private Album retornarAlbumDoForm()
        {
            var artista = new Artista {
                id = Convert.ToInt32(ddlArtista.SelectedValue)
            };
            
            var album = new Album(artista);
            album.id = Convert.ToInt32(hdnCodigo.Value);
            album.titulo = txtTitulo.Text;
            album.ano_lancamento = Convert.ToInt32(txtAnoLancamento.Text);

            return album;
        }
    }
}