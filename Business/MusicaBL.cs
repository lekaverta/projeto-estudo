using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using DAL;

namespace Business
{
    public class MusicaBL
    {
        public void salvar(Musica musica)
        {
            new MusicaDAL().salvar(musica);
        }

        public List<Musica> listarTodos()
        {
            return new MusicaDAL().listarTodos();
        }

        public Musica buscarPorId(Musica musica)
        {
            return new MusicaDAL().buscarPorId(musica);
        }

        public List<Musica> buscarPorFiltro(Dictionary<String, object> filtros)
        {
            return new MusicaDAL().buscarPorFiltro(filtros);
        }
    }
}
