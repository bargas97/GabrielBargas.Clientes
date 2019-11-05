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
    public class SegmentoData:ISegmentoData
    {
        #region parametros

        private readonly Conexao conexao;

        #endregion

        #region Construtor

        public SegmentoData(Conexao Conexao)
        {
            this.conexao = Conexao;
        }

        #endregion

        #region Metodos Publicos

        public IEnumerable<SEGMENTO> ListarSegmentos()
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    string sql = "SELECT * FROM SEGMENTO";

                    var segmentos = con.QueryAsync<SEGMENTO>(sql).Result.ToList();

                    return segmentos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CadastrarSegmento(SEGMENTO SEGMENTO)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    string sql = "INSERT INTO SEGMENTO(DESCRICAO) " +
                        "VALUES(@descricao)";
                    var tabAfetada = await con.ExecuteAsync(sql, new
                    {
                        descricao = SEGMENTO.DESCRICAO
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SEGMENTO BuscarSegmento(int id)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    var sql = "SELECT * FROM SEGMENTO WHERE ID_SEGMENTO =@id ";

                    var SEGMENTO = con.QueryFirstAsync<SEGMENTO>(sql, new { id }).Result;

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
