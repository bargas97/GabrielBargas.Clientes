using GabrielBargas.Clientes.Database.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielBargas.Clientes.Database.Interfaces
{
    public interface IEnderecoData
    {
        Task<IEnumerable<ENDERECO>> ListarEnderecosCliente(int idCliente);

        Task CadastrarEndereco(ENDERECO endereco);

        Task<ENDERECO> BuscarEndereco(int id);
    }
}
