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
        List<ENDERECO> ListarEnderecosCliente(int idCliente);

        Task CadastrarEndereco(ENDERECO endereco);

        Task AlterarEndereco(ENDERECO endereco);

        ENDERECO BuscarEndereco(int id);
    }
}
