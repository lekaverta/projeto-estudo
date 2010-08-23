using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL.Base
{
    public interface DALInterface
    {
        void limparComando();

        void destruir();

        void criarParametro(string nomeParametro, object valorParametro);
        
        void executar(string comandoTexto);

        DataTable executarDataTable(string comandoTexto);

        object executarScalar(string comandoTexto);
    }
}
