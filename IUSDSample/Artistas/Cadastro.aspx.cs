using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using System.Drawing;
using Models;

namespace IUSDSample.Artistas
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                editarArtista();
        }

        private void editarArtista()
        {
            if (Request.QueryString.Get("codigo") != null)
            {
                var artista = ArtistaBL.buscarPorId(new Artista {
                    id = Convert.ToInt32(Request.QueryString.Get("codigo")) 
                });

                carregarArtistaEmForm(artista);
            }
        }

        private void carregarArtistaEmForm(Artista artista)
        {
            hdnCodigo.Value = artista.id.ToString();
            txtTitulo.Text = artista.titulo;
            txtBiografia.Text = artista.biografia;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var artista = retornarArtistaDoForm();
                ArtistaBL.salvar(artista);

                hdnCodigo.Value = artista.id.ToString();
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

        private Artista retornarArtistaDoForm()
        {
            return new Artista
            {
                id = Convert.ToInt32(hdnCodigo.Value),
                titulo = txtTitulo.Text,
                biografia = txtBiografia.Text
            };
        }
    }
}