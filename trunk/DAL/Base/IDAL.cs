using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using DAL.Base;

namespace DAL
{
    public abstract class IDAL<T>
    {
        public DALInterface dal;

        public abstract String tabela();
        public abstract String colunaPK();
        public abstract List<String> colunas();
        public abstract T mapearObjeto(DataRow reader);

        public IDAL()
        {
            this.dal = new DAL();
        }

        protected virtual String getTablePK()
        {
            return "id";
        }

        public void salvar(T item)
        {
            dal.limparComando();
            
            var value = retornarValorPK(item);
            if (value != null && !value.Equals(0))
                atualizar(item);
            else
                inserir(item);
        }

        private void inserir(T item)
        {
            dal.limparComando();
            var comandoInsert = sqlInsert();

            comandoInsert = criarParametrosPorObjeto(item, comandoInsert);

            PropertyInfoColuna(getTablePK()).SetValue
            (
                item, 
                Convert.ToInt32(dal.executarScalar(comandoInsert)), 
                null
            );

            this.dal.destruir();
        }

        private void atualizar(T item)
        {
            dal.limparComando();
            var comandoUpdate = sqlUpdate();

            comandoUpdate = criarParametrosPorObjeto(item, comandoUpdate);
            dal.criarParametro("?id", retornarValorPK(item));
            dal.executar(comandoUpdate);

            this.dal.destruir();
        }

        public void delete(T item)
        {
            dal.limparComando();

            dal.criarParametro("?id", retornarValorPK(item));
            dal.executar(sqlDelete());

            this.dal.destruir();
        }
        
        public List<T> listarTodos()
        {
            dal.limparComando();
            var retorno = executar(sqlListarTodos());
            this.dal.destruir();

            return retorno;
        }

        public T buscarPorId(T item)
        {
            dal.limparComando();

            var resultados = executar(sqlListarPorId(item));

            this.dal.destruir();

            if (resultados != null && resultados.Count > 0)
                return resultados.First();
            else
                return default(T);
        }

        public List<T> buscarPorFiltro(Dictionary<String, object> filtros)
        {
            dal.limparComando();

            var comandoBuscar = sqlBuscarPorFiltro(filtros);
            return executar(comandoBuscar);
        }

        private List<T> executar(String comando)
        {
            var resultadoLista = new List<T>();
            var resultado = dal.executarDataTable(comando);

            foreach (DataRow dr in resultado.Rows)
                resultadoLista.Add(mapearObjeto(dr));

            return resultadoLista;
        }

        private string criarParametrosPorObjeto(T item, String comando)
        {
            foreach (String coluna in colunas())
            {
                var valor = retornarValorColuna(item, coluna);

                if (valor == null)
                    dal.criarParametro(String.Format("?{0}", coluna), DBNull.Value);
                else if (valor.GetType().ToString().Contains("Models"))
                {
                    var valorI = valor.GetType().GetProperty("id").GetValue(valor, null);
                    comando = renomearECriarParametro(comando, coluna, valorI);
                }
                else
                    dal.criarParametro(String.Format("?{0}", coluna), valor);
            }
            return comando;
        }

        private string renomearECriarParametro(String comando, String coluna, object valor)
        {
            comando = comando.Replace(coluna, String.Format("{0}_ID", coluna));
            dal.criarParametro(String.Format("?{0}_ID", coluna), valor);
            return comando;
        }

        private object retornarValorPK(T item)
        {
            return PropertyInfoColuna(colunaPK())
                        .GetValue(item, null);
        }

        private object retornarValorColuna(T item, String coluna)
        {
            return PropertyInfoColuna(coluna)
                        .GetValue(item, null);
        }

        private PropertyInfo PropertyInfoColuna(String coluna)
        {
            var colunaPI = typeof(T).GetProperty(titulo(coluna));

            if (colunaPI == null)
                colunaPI = typeof(T).GetProperty(coluna);

            return colunaPI;
        }

        private String titulo(String nome)
        {
            return nome.ToLower()
                       .Replace(" ", "");
        }


        #region querys

        private String sqlBuscarPorFiltro(Dictionary<String, object> filtros)
        {
            var comando = new StringBuilder(sqlListarTodos());

            if (filtros != null && filtros.Count > 0)
            {
                comando.Append(" WHERE ");

                foreach (String coluna in filtros.Keys)
                {
                    if (!comando.ToString().EndsWith("WHERE "))
                        comando.Append(" AND ");

                    comando.Append(String.Format("{0} = ?{0}", coluna));

                    var valor = filtros[coluna];

                    if (valor.GetType().ToString().Contains("Models"))
                    {
                        valor = valor.GetType()
                                     .GetProperty("id")
                                     .GetValue(valor, null);

                        if (!coluna.ToLower().EndsWith("id"))
                            comando = new StringBuilder(renomearECriarParametro(comando.ToString(), coluna, valor));
                        else
                            dal.criarParametro(String.Format("?{0}", coluna), valor);
                    }
                    else
                        dal.criarParametro(String.Format("?{0}", coluna), valor);
                }
            }

            return comando.ToString();
        }

        private String sqlListarTodos()
        {
            return String.Format("SELECT * FROM {0}", tabela());
        }
        
        private String sqlListarPorId(T item)
        {
            dal.criarParametro("?id", retornarValorPK(item));
            return String.Format
            (
                String.Concat(sqlListarTodos(), " WHERE {0} = ?id"),
                getTablePK()
            );
        }

        private String sqlDelete()
        {
            return String.Format("DELETE FROM {0} WHERE {1} = ?id", tabela(), colunaPK());
        }

        private String sqlInsert()
        {
            String sql = "INSERT INTO {0} ({1}) VALUES ({2}); SELECT @@identity",
                parametros = String.Join(", ", colunas().ToArray<String>());
            var valores = new StringBuilder();

            foreach (String coluna in colunas())
            {
                if (valores.ToString() != String.Empty)
                    valores.Append(", ");

                valores.Append(String.Format("?{0}", coluna));
            }

            return String.Format(sql, tabela(), parametros, valores);
        }

        private String sqlUpdate()
        {
            var sql = "UPDATE {0} SET {1} WHERE {2} = ?id";
            var valores = new StringBuilder();

            foreach (String coluna in colunas())
            {
                if (valores.ToString() != String.Empty)
                    valores.Append(", ");

                valores.Append(String.Format("{0} = ?{0}", coluna));
            }

            return String.Format(sql, tabela(), valores, colunaPK());
        }

        #endregion
    }
}