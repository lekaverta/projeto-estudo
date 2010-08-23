using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using MySql.Data.MySqlClient;
using System.Data;
using DAL.Base;

namespace DAL
{
    public class ArtistaDAL : IDAL<Artista>
    {
        public ArtistaDAL(DALInterface dal)
        {
            this.dal = dal;
        }

        public ArtistaDAL()
        {
            this.dal = new DAL();
        }

        public override String tabela()
        {
            return "tbartistas";
        }

        public override String colunaPK()
        {
            return "id";
        }

        public override List<String> colunas()
        {
            return new List<String>() { "titulo", "biografia" };
        }

        public override Artista mapearObjeto(DataRow reader)
        {
            return new Artista()
            {
                id = Convert.ToInt32(reader["id"]),
                titulo = reader["titulo"].ToString(),
                biografia = reader["biografia"].ToString()
            };
        }
    }
}
