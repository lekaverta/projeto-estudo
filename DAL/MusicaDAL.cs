using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public class MusicaDAL : IDAL<Musica>
    {
        public override String tabela()
        {
            return "tbmusicas";
        }

        public override String colunaPK()
        {
            return "id";
        }

        public override List<String> colunas()
        {
            return new List<String>() { "artista", "album", "titulo" };
        }

        public override Musica mapearObjeto(DataRow reader)
        {
            var artista = new ArtistaDAL().buscarPorId(new Artista { id = Convert.ToInt32(reader["artista_id"]) });

            var album = new Album(artista);
            album.id = Convert.ToInt32(reader["album_id"]);
            album = new AlbumDAL().buscarPorId(album);

            var musica = new Musica(album);
            musica.id = Convert.ToInt32(reader["id"]);
            musica.titulo = reader["titulo"].ToString();
            musica.artista = artista;

            return musica;
        }
    }
}
