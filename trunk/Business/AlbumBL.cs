using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace Business
{
    public class AlbumBL
    {
        public void salvar(Album album)
        {
            new AlbumDAL().salvar(album);
        }

        public List<Album> listarTodos()
        {
            return new AlbumDAL().listarTodos();
        }

        public Album buscarPorId(Album album)
        {
            return new AlbumDAL().buscarPorId(album);
        }

        public List<Album> buscarPorFiltro(Dictionary<String, object> filtros)
        {
            return new AlbumDAL().buscarPorFiltro(filtros);
        }
    }
}
