using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public class DAL
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;
        
        public DAL()
        {
            setarConexao(ConfigurationManager.ConnectionStrings["conexaoDefault"].ConnectionString);
        }

        public DAL(string stringConexao)
        {
            setarConexao(stringConexao);
        }


        public void limparComando()
        {
            if (this.comando != null)
            {
                this.comando.Parameters.Clear();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = String.Empty;
            }
        }

        public void destruir()
        {
            if (conexao.State.Equals(ConnectionState.Open))
                conexao.Close();

            conexao = null;
            comando = null;
        }


        protected void setarConexao(string stringConexao)
        {
            this.conexao = new MySqlConnection(stringConexao);
            comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.Connection.Open();
        }

        private void setarComando(string comandoTexto)
        {
            comando.CommandText = comandoTexto;
        }

        public void criarParametro(string nomeParametro, object valorParametro)
        {
            this.comando.Parameters.AddWithValue(nomeParametro, valorParametro);
        }


        public void executar(string comandoTexto)
        {
            setarComando(comandoTexto);
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
        }

        public DataTable executarDataTable(string comandoTexto)
        {
            var retorno = new DataTable();
            try
            {
                setarComando(comandoTexto);
                this.comando.Parameters.Clear();
                var dp = new MySqlDataAdapter();
                dp.SelectCommand = this.comando;

                dp.Fill(retorno);
            }
            catch (MySqlException ex)
            {
            }
            catch (Exception ex)
            {
            }

            return retorno;
        }

        public object executarScalar(string comandoTexto)
        {
            setarComando(comandoTexto);
            return comando.ExecuteScalar();
        }
        
    }
}
