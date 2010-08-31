using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace Business
{
    public abstract class IBL<T, DAL> where DAL : IDAL<T>, new()
    {
        public void salvar(T item)
        {
            new DAL().salvar(item);
        }

        public static void deletar(T item)
        {
            new DAL().delete(item);
        }

        public static List<T> listarTodos()
        {
            return new DAL().listarTodos();
        }

        public static T buscarPorId(T item)
        {
            return new DAL().buscarPorId(item);
        }

        public static List<T> buscarPorFiltro(Dictionary<String, object> filtros)
        {
            return new DAL().buscarPorFiltro(filtros);
        }
    }
}
