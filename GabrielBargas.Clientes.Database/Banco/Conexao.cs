using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielBargas.Clientes.Database.Banco
{
    public class Conexao
    {
        public string ConexaoBD()
        {
            string strConexao = ConfigurationManager.ConnectionStrings["banco"].ConnectionString;
            return strConexao;
        }
    }
}
