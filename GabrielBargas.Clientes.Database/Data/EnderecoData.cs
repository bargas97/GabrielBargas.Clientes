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
    public class EnderecoData: IEnderecoData
    {
        #region parametros

        private readonly Conexao conexao;

        #endregion

        #region Construtor

        public EnderecoData(Conexao Conexao)
        {
            this.conexao = Conexao;
        }

        #endregion

        #region Metodos Publicos
        
        public List<ENDERECO> ListarEnderecosCliente(int idCliente)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    string sql = "SELECT * FROM ENDERECO WHERE ID_CLIENTE = @idCliente;";

                    var enderecos = con.QueryAsync<ENDERECO>(sql,new { idCliente}).Result.ToList();

                    return enderecos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CadastrarEndereco(ENDERECO endereco)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    string sql = "INSERT INTO ENDERECO(ESTADO,CIDADE,CEP,RUA,NUMERO,COMPLEMENTO,TIPO_ENDERECO,ID_CLIENTE) " +
                        "VALUES(@estado,@cidade,@cep,@rua,@numero,@complemento,@tipoEndereco,@idCliente)";
                    var tabAfetada = await con.ExecuteAsync(sql, new
                    {
                        estado = endereco.ESTADO,
                        cidade = endereco.CIDADE,
                        cep = endereco.CEP,
                        rua = endereco.RUA,
                        numero = endereco.NUMERO,
                        complemento = endereco.COMPLEMENTO,
                        tipoEndereco = endereco.TIPO_ENDERECO,
                        idCliente = endereco.ID_CLIENTE
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task AlterarEndereco(ENDERECO endereco)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    string sql =
                        "UPDATE ENDERECO " +
                            "SET " +
                                "ESTADO = @estado, " +
                                "CIDADE = @cidade, " +
                                "CEP = @cep, " +
                                "RUA = @rua, " +
                                "NUMERO = @numero, " +
                                "COMPLEMENTO =@complemento, " +
                                "TIPO_ENDERECO =@tipoEndereco " +
                                "WHERE ID_ENDERECO = @idEndereco;";

                    await con.ExecuteAsync(sql, new
                    {
                        estado = endereco.ESTADO,
                        cidade = endereco.CIDADE,
                        cep = endereco.CEP,
                        rua = endereco.RUA,
                        numero = endereco.NUMERO,
                        complemento = endereco.COMPLEMENTO,
                        tipoEndereco = endereco.TIPO_ENDERECO,
                        idEndereco = endereco.ID_ENDERECO
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ENDERECO BuscarEndereco(int id)
        {
            try
            {
                using (var con = new SqlConnection(this.conexao.ConexaoBD()))
                {
                    var sql = "SELECT * FROM ENDERECO WHERE ID_ENDERECO =@id ";

                    var endereco = con.QueryFirstAsync<ENDERECO>(sql, new { id }).Result;

                    return endereco;
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
