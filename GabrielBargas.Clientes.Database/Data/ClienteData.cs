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
    public class ClienteData: IClienteData
    {
        #region Parametros

        private readonly Conexao conexao;

        #endregion

        #region Construtor

        public ClienteData(Conexao Conexao)
        {
            this.conexao = Conexao;
        }

        #endregion

        #region Metodos publicos

        public IEnumerable<CLIENTE> ListarClientes()
        {
            try
            {
                using (var con = new SqlConnection(conexao.ConexaoBD()))
                {
                    string sql = "SELECT * FROM CLIENTE WHERE FLAG_INATIVO IS NULL or FLAG_INATIVO =0;";
                    var clientes = con.QueryAsync<CLIENTE>(sql).Result.ToList();

                    return clientes ;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CadastrarCliente(CLIENTE cliente)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    string sql = "INSERT INTO CLIENTE(NOME,CPF_CNPJ,TEL_PRINCIPAL,TEL_ALTERNATIVO,CLASSIFICACAO,ID_SEGMENTO) " +
                        "VALUES(@nomeCliente,@cpfCnpj,@telPrincipal,@telAlternativo,@classificacao,@segmento)";

                    await con.ExecuteAsync(sql, new
                    {
                        nomeCliente = cliente.NOME,
                        cpfCnpj = cliente.CPF_CNPJ,
                        telPrincipal = cliente.TEL_PRINCIPAL,
                        telAlternativo = cliente.TEL_ALTERNATIVO,
                        classificacao = cliente.CLASSIFICACAO,
                        segmento = cliente.ID_SEGMENTO
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task AtualizarCliente(CLIENTE cliente,bool FlagInativo)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    string sql =
                        "UPDATE CLIENTE "+
                            "SET "+
                                "NOME = @nomeCliente, " +
                                "CPF_CNPJ = @cpfCnpj, " +
                                "TEL_PRINCIPAL = @telPrincipal, " +
                                "TEL_ALTERNATIVO = @telAlternativo, " +
                                "CLASSIFICACAO = @classificacao, " +
                                "ID_SEGMENTO =@segmento, " +
                                "FLAG_INATIVO =@flagInativo " +
                                "WHERE ID_CLIENTE = @idCliente;";

                    await con.ExecuteAsync(sql, new
                    {
                        idCliente = cliente.ID_CLIENTE,
                        nomeCliente = cliente.NOME,
                        cpfCnpj = cliente.CPF_CNPJ,
                        telPrincipal = cliente.TEL_PRINCIPAL,
                        telAlternativo = cliente.TEL_ALTERNATIVO,
                        classificacao = cliente.CLASSIFICACAO,
                        segmento = cliente.ID_SEGMENTO,
                        flagInativo = FlagInativo
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CLIENTE BuscarCliente(int id)
        {
            try
            {
               using(var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    var sql = "SELECT * FROM CLIENTE WHERE ID_CLIENTE =@id ";

                    var cliente = con.QueryFirstAsync<CLIENTE>(sql, new { id }).Result;

                    return cliente;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        #endregion
    }
}