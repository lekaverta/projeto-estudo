using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace Business
{
    public class ArtistaBL
    {
        public void salvar(Artista artista)
        {
            new ArtistaDAL().salvar(artista);
        }

        public List<Artista> listarTodos()
        {
            return new ArtistaDAL().listarTodos();
        }

        public Artista buscarPorId(Artista artista)
        {
            return new ArtistaDAL().buscarPorId(artista);
        }

        public List<Artista> buscarPorFiltro(Dictionary<String, object> filtros)
        {
            return new ArtistaDAL().buscarPorFiltro(filtros);
        }
    }
}
