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
            return new Album()
            {
                id = Convert.ToInt32(reader["id"]),
                artista = new Artista { id = Convert.ToInt32(reader["artista_id"]) },
                titulo = reader["titulo"].ToString(),
                ano_lancamento = Convert.ToInt32(reader["ano_lancamento"])
            };
        }
    }
}
