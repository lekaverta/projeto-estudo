using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Business;

namespace IUSDSample
{
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                listarRegistros();
        }

        private void listarRegistros()
        {
            var musicas = buscarMusicas();
            gdvRegistros.DataSource = musicas;
            gdvRegistros.DataBind();
        }

        private List<Musica> buscarMusicas()
        {
            var musicas = new List<Musica>();

            if (Request.QueryString.Get("artista") != null
                || Request.QueryString.Get("album") != null)
            {
                var filtros = montarFiltros();
                musicas = MusicaBL.buscarPorFiltro(filtros);
            }
            else
                musicas = MusicaBL.listarTodos();

            return musicas;
        }

        private Dictionary<string, object> montarFiltros()
        {
            var filtros = new Dictionary<string, object>();
            
            if (Request.QueryString.Get("album") != null)
            {
                var album = new Album(new Artista());
                album.id = Convert.ToInt32(Request.QueryString.Get("album"));

                filtros.Add("album", album);
            }
            else if (Request.QueryString.Get("artista") != null)
            {
                var artista = new Artista {
                    id = Convert.ToInt32(Request.QueryString.Get("artista"))
                };

                filtros.Add("artista", artista);
            }

            return filtros;
        }

        protected void lkbExcluir_Click(object sender, EventArgs e)
        {
            var lkbExcluir = (LinkButton)sender;
            
            var musicaDeletada = new Musica(new Album(new Artista()));
            musicaDeletada.id = Convert.ToInt32(lkbExcluir.CommandArgument);
            MusicaBL.deletar(musicaDeletada);

            listarRegistros();
        }
    }
}