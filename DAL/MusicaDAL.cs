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
            AlbumDAL albumDAL = new AlbumDAL();
            ArtistaDAL artistaDAL = new ArtistaDAL();

            return new Musica()
            {
                id = Convert.ToInt32(reader["id"]),
                //artista = new Artista() { id = Convert.ToInt32(reader["artista_id"]) },
                //album = new Album() { id = Convert.ToInt32(reader["album_id"]) },
                artista = artistaDAL.buscarPorId(new Artista() { id = Convert.ToInt32(reader["artista_id"]) }),
                album = albumDAL.buscarPorId(new Album() { id = Convert.ToInt32(reader["album_id"]) }),
                titulo = reader["titulo"].ToString()
            };
        }
    }
}
