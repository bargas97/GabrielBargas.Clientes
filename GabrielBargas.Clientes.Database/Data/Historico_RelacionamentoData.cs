using Dapper;
using GabrielBargas.Clientes.Database.Banco;
using GabrielBargas.Clientes.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielBargas.Clientes.Database.Data
{
    public class Historico_RelacionamentoData: IHistorico_RelacionamentoData
    {
        #region parametros

        private readonly Conexao conexao;

        #endregion

        #region Construtor

        public Historico_RelacionamentoData(Conexao Conexao)
        {
            this.conexao = Conexao;
        }

        #endregion

        #region Metodos Publicos

        public List<HISTORICO_RELACIONAMENTO> ListarHistoricoRelacionamentosCliente(int idCliente)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    string sql = "SELECT * FROM HISTORICO_RELACIONAMENTO WHERE ID_CLIENTE = @idCliente";

                    var histRelacionamento = con.QueryAsync<HISTORICO_RELACIONAMENTO>(sql,new { idCliente}).Result.ToList();

                    return histRelacionamento;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CadastrarHistoricoRelacionamento(HISTORICO_RELACIONAMENTO historicoRelacionamento)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    string sql = "INSERT INTO HISTORICO_RELACIONAMENTO(DESCRICAO,DATA_HISTORICO,ID_CLIENTE) " +
                        "VALUES(@descricao,@dataHistorico,@idCliente)";
                    var tabAfetada = await con.ExecuteAsync(sql, new
                    {
                       descricao = historicoRelacionamento.DESCRICAO,
                       dataHistorico = historicoRelacionamento.DATA_HISTORICO,
                       idcliente = historicoRelacionamento.ID_CLIENTE
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<HISTORICO_RELACIONAMENTO> BuscarHistoricoRelaciomento(int id)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    var sql = "SELECT * FROM HISTORICO_RELACIONAMENTO WHERE ID_HISTORICO_RELACIONAMENTO =@id ";

                    var SEGMENTO = await con.QueryFirstAsync<HISTORICO_RELACIONAMENTO>(sql, new { id });

                    return SEGMENTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
