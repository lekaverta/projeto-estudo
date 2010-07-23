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

        private List<Musica> simularRetornoDeDados()
        {
            var musicaList = new List<Musica>();

            var losHermanos = new Artista { titulo = "Los Hermanos", id = 1 };
            
            var ventura = new Album(losHermanos);
            ventura.id = 2;
            ventura.titulo = "Ventura";

            var quatro = new Album(losHermanos);
            quatro.id = 1;
            quatro.titulo = "4";

            var blocoDoEuSozinho = new Album(losHermanos);
            blocoDoEuSozinho.id = 3;
            blocoDoEuSozinho.titulo = "Bloco Do EU Sozinho";

            var sambaADois = new Musica(ventura);
            sambaADois.id = 1;
            sambaADois.titulo = "Samba a dois";
            musicaList.Add(sambaADois);

            var umPar = new Musica(ventura);
            umPar.id = 2;
            umPar.titulo = "Um Par";
            musicaList.Add(umPar);

            var poisE = new Musica(ventura);
            poisE.id = 3;
            poisE.titulo = "Pois é";
            musicaList.Add(poisE);

            var taBom = new Musica(quatro);
            taBom.id = 4;
            taBom.titulo = "Ta Bom";
            musicaList.Add(taBom);

            var horizonteDistante = new Musica(blocoDoEuSozinho);
            horizonteDistante.id = 5;
            horizonteDistante.titulo = "Horizonte Distante";
            musicaList.Add(horizonteDistante);

            return musicaList;
        }
    }
}