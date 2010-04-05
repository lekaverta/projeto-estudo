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
            gdvRegistros.DataSource = new MusicaBL().listarTodos();
            gdvRegistros.DataBind();
        }

        private List<Musica> simularRetornoDeDados()
        {
            var musicaList = new List<Musica>();
            musicaList.Add(new Musica
            {
                id = 1,
                titulo = "Samba a dois",
                album = new Album { titulo = "Ventura", id = 2 },
                artista = new Artista { titulo = "Los Hermanos", id = 1 }
            });
            musicaList.Add(new Musica
            {
                id = 2,
                titulo = "Um Par",
                album = new Album { titulo = "Ventura", id = 2 },
                artista = new Artista { titulo = "Los Hermanos", id = 1 }
            });
            musicaList.Add(new Musica
            {
                id = 3,
                titulo = "Pois É",
                album = new Album { titulo = "Bloco Do EU Sozinho", id = 3 },
                artista = new Artista { titulo = "Los Hermanos", id = 1 }
            });
            musicaList.Add(new Musica
            {
                id = 4,
                titulo = "Tá Bom",
                album = new Album { titulo = "Ventura", id = 2 },
                artista = new Artista { titulo = "Los Hermanos", id = 1 }
            });
            musicaList.Add(new Musica
            {
                id = 5,
                titulo = "Horizonte Distante",
                album = new Album { titulo = "4", id = 1 },
                artista = new Artista { titulo = "Los Hermanos", id = 1 }
            });

            return musicaList;
        }
    }
}