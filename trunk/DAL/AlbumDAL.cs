using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public class AlbumDAL : IDAL<Album>
    {
        public override String tabela()
        {
            return "tbalbums";
        }

        public override String colunaPK()
        {
            return "id";
        }

        public override List<String> colunas()
        {
            return new List<String>() { "artista", "titulo", "ano_lancamento" };
        }

        public override Album mapearObjeto(DataRow reader)
        {
            var artista = new ArtistaDAL().buscarPorId(new Artista { id = Convert.ToInt32(reader["artista_id"]) });

            var album = new Album(artista);
            album.id = Convert.ToInt32(reader["id"]);
            album.titulo = reader["titulo"].ToString();
            album.ano_lancamento = Convert.ToInt32(reader["ano_lancamento"]);

            return album;
        }
    }
}
